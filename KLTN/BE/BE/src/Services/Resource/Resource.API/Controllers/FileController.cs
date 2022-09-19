using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Resource.API.Persistences;
using Service.Core.Object;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace Resource.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class FileController : ControllerBase
    {
        private string contentRootPath = "";
        private readonly ResourceDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private IWebHostEnvironment _hostEnv;
        private IHttpContextAccessor _httpContext;
        public FileController(ResourceDbContext dbContext, IConfiguration configuration, IWebHostEnvironment hostEnv, IHttpContextAccessor httpContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _hostEnv = hostEnv;
            _httpContext = httpContext;
            contentRootPath = hostEnv.ContentRootPath;
        }
        [HttpGet("stream")]
        public async Task<IActionResult> GetFile([FromQuery] string filePath)
        {
            if (!await _dbContext.Files.AnyAsync(x => x.FilePath == filePath))
            {
                return NotFound();
            }
            return PhysicalFile(filePath, "application/octet-stream", enableRangeProcessing: true);
        }
        [HttpPost("zip")]
        public async Task<IActionResult> DownloadZip([FromBody] List<Guid> ids, [FromQuery] string sectionName)
        {
            string filePath = Path.Combine(contentRootPath, "assets");
            using (ZipArchive zip = ZipFile.Open(Path.Combine(filePath, $"{sectionName.Replace(" ", "_")}.zip"), ZipArchiveMode.Create))
            {
                foreach (var id in ids)
                {
                    var file = await _dbContext.Files.FirstOrDefaultAsync(x => x.Id == id);
                    if (file != null)
                    {
                        zip.CreateEntryFromFile(file.AbsolutePath ?? file.FilePath, file.FileName);

                    }
                }
                return PhysicalFile(Path.Combine(filePath, $"{sectionName.Replace(" ", "_")}.zip"), "application/octet-stream");
            }
        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromQuery] int directoryId = 0)
        {
            string filePath = Path.Combine(contentRootPath, "assets");
            var upload = Path.Combine(contentRootPath, filePath);
            if (!Directory.Exists(upload))
            {
                Directory.CreateDirectory(upload);
            }
            using (var fileStream = new FileStream(Path.Combine(upload, file.FileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            string finalPath = GetAppBaseUrl(Path.Combine("assets", file.FileName));
            string absolutePath = Path.Combine(upload, file.FileName);
            Service.Core.Models.Resources.File uploadedFile = new Service.Core.Models.Resources.File()
            {
                FilePath = finalPath,
                FileName = file.FileName,
                AbsolutePath = absolutePath
            };
            if (directoryId != 0)
            {
                uploadedFile.DirectoryId = directoryId;
            }
            var extension = Path.GetExtension(file.FileName);
            uploadedFile.FileType = extension.Substring(1);
            _dbContext.Add(uploadedFile);
            await _dbContext.SaveChangesAsync();
            return Ok(new FileUploadResponse
            {
                Id = uploadedFile.Id,
                FilePath = uploadedFile.FilePath,
                FileName = file.FileName,
                AbsolutePath = absolutePath,
                FileType = uploadedFile.FileType,
            });
        }
        [HttpPost("domain/{id}/folder/{folderId}")]
        public async Task<IActionResult> UploadToFolder([FromRoute] Guid id, [FromRoute] int folderId, [FromForm] IFormFile file)
        {
            var folder = await _dbContext.DomainDirectories.FirstOrDefaultAsync(x => x.DomainId == id && x.Id == folderId);
            if (folder == null)
            {
                return NotFound();
            }
            return await UploadFile(file, folderId);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditFile(Guid id, [FromForm] IFormFile file)
        {
            Service.Core.Models.Resources.File localFile = await _dbContext.Files.FirstOrDefaultAsync(x => x.Id == id);
            if (localFile == null)
            {
                return NotFound();
            }
            if (file != null)
            {
                if (DeleteFile(localFile.FilePath))
                {
                    _dbContext.Files.Remove(localFile);
                    await _dbContext.SaveChangesAsync();
                    return await UploadFile(file);
                }
                return BadRequest();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Service.Core.Models.Resources.File localFile = await _dbContext.Files.FirstOrDefaultAsync(x => x.Id == id);
            if (localFile == null)
            {
                return NotFound();
            }
            if (DeleteFile(localFile.AbsolutePath))
            {
                _dbContext.Remove(localFile);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("physical")]
        public async Task<IActionResult> DeletePhysical([FromRoute] string filePath)
        {
            Service.Core.Models.Resources.File localFile = await _dbContext.Files.FirstOrDefaultAsync(x => x.FilePath == filePath);
            if (localFile == null)
            {
                return NotFound();
            }
            if (DeleteFile(localFile.AbsolutePath))
            {
                _dbContext.Remove(localFile);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
        private bool DeleteFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                return true;
            }
            return false;
        }
        private string GetAppBaseUrl(string saveLocation)
        {

            return string.Format("{0}://{1}/{2}{3}", _httpContext.HttpContext.Request.Scheme, _httpContext.HttpContext.Request.Host, _httpContext.HttpContext.Request.PathBase, saveLocation);
        }
        private string GetStreamBaseUrl(string saveLocation)
        {

            return string.Format("{0}://{1}/{2}{3}{4}", _httpContext.HttpContext.Request.Scheme, _httpContext.HttpContext.Request.Host, _httpContext.HttpContext.Request.PathBase, "api/file/stream?filename=", saveLocation);
        }
    }
}
