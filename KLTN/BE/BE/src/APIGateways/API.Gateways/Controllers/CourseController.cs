using API.Gateways.Models;
using API.Gateways.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace API.Gateways.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CourseController : ControllerBase
    {
        private readonly SubjectGrpcService _subjectService;
        private readonly IIdentityService _identityService;
        private readonly IInfrastructureService _infraService;
        private readonly ICRMService _crmService;
        private readonly IMapper _mapper;
        public CourseController(SubjectGrpcService subjectService, IIdentityService identityService, IMapper mapper, IInfrastructureService infraService, ICRMService crmService)
        {
            _subjectService = subjectService;
            _identityService = identityService;
            _mapper = mapper;
            _infraService = infraService;
            _crmService = crmService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid domainId)
        {
            var task0 = _identityService.GetDomain(domainId);
            var task1 = _subjectService.GetClassByDomain(domainId);
            var task2 = _subjectService.GetStudentsByDomain(domainId);
            var task3 = _subjectService.GetTeachersByDomain(domainId);
            var task4 = _subjectService.GetSemesterByDomain(domainId, DateTime.Now.Year);
            var task5 = _subjectService.GetSubjectsByDomain(domainId);

            var data0 = await task0;
            var data1 = await task1;
            var data2 = await task2;
            var data3 = await task3;
            var data4 = await task4;
            var data5 = await task5;
            var result = new
            {
                domain = data0,
                teachers = data3,
                students = data2,
                semesters = data4,
                classes = data1,
                subjects = data5
            };
            return Ok(result);
        }
        [HttpGet("exams")]
        public async Task<IActionResult> GetExams([FromQuery] Guid teacherId)
        {
            return Ok(await _subjectService.GetExam(teacherId));
        }
        [HttpPost("sections/scripts")]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<IActionResult> CRUDScript([FromRoute] int id, [FromForm] ScriptDTO script)
        {
            bool result = false;
            switch (script.ScriptType)
            {
                case "ContextScript":
                    var context = _mapper.Map<ContextScriptDTO>(script);
                    result = await _subjectService.CRUDContextScript(context);
                    break;
                case "ExamScript":
                    var exam = _mapper.Map<ExamScriptDTO>(script);
                    result = await _subjectService.CRUDExamScript(exam);
                    break;
                case "DocumentScript":
                    if (!string.IsNullOrEmpty(script.DocumentUrl))
                    {
                        await _infraService.DeleteFile(script.DocumentUrl);
                    }
                    var uploadResult = await _infraService.UploadFile(script.File);

                    var document = _mapper.Map<DocumentScriptDTO>(script);
                    document.DocumentUrl = uploadResult.FilePath;
                    document.FileId = uploadResult.Id;
                    document.FileType = uploadResult.FileType;
                    if (!string.IsNullOrEmpty(script.DocumentTitle))
                    {
                        document.DocumentTitle = script.DocumentTitle;
                    }
                    result = await _subjectService.CRUDDocumentScript(document);
                    break;
                case "AssignmentScript":
                    var assignment = _mapper.Map<AssignmentScriptDTO>(script);
                    result = await _subjectService.CRUDAssignmentScript(assignment);
                    break;
                case "QuizScript":
                    break;
                case "VideoScript":
                    var video = _mapper.Map<VideoScriptDTO>(script);
                    if (script.File != null)
                    {
                        if (!string.IsNullOrEmpty(script.VideoPath) && script.VideoId != Guid.Empty)
                        {
                            await _infraService.DeleteFile(script.VideoId);
                        }
                        var upload = await _infraService.UploadFile(script.File);
                        video.VideoPath = upload.FilePath;
                        video.VideoId = upload.Id;
                    }
                    result = await _subjectService.CRUDVideoScript(video);
                    break;
                default:
                    break;
            }
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("sections/scripts/{id}/submit")]
        public async Task<IActionResult> SubmitFile([FromRoute] int id, [FromQuery] Guid studentId, [FromForm] IFormFile file)
        {
            var uploadFileResult = await _infraService.UploadFile(file);
            var result = await _subjectService.SubmitAssignment(id, 1, uploadFileResult.Id, uploadFileResult.FilePath, uploadFileResult.FileName, studentId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("sections/scripts/{id}/delete")]
        public async Task<IActionResult> DeleteFile([FromRoute] int id, [FromQuery] Guid submitId, [FromQuery] Guid fileId)
        {
            var deleteFileResult = await _infraService.DeleteFile(fileId);
            if (deleteFileResult)
            {
                var result = await _subjectService.DeleteAssignment(id, submitId);
                if (result)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return BadRequest();

        }
        [HttpGet("availableteacher")]
        public async Task<IActionResult> GetAvailableTeacher([FromQuery] Guid id)
        {
            var result = await _subjectService.GetAvailableTeachers(id);
            return Ok(result);
        }
        [HttpGet("sections/{id}/assignment")]
        public async Task<IActionResult> GetStudentAssignment([FromRoute] Guid id)
        {
            return Ok(await _subjectService.GetStudentAssignments(id));
        }
        [HttpGet("{id}/student")]
        public async Task<IActionResult> GetClassStudent([FromRoute] int id)
        {
            return Ok(await _subjectService.GetClassStudent(id));
        }
        [HttpGet("{id}/assignment/result")]
        public async Task<IActionResult> GetAssignmentResult([FromRoute] int id, [FromQuery] Guid studentId)
        {
            return Ok(await _subjectService.GetAssignmentResult(studentId, id));
        }
        [HttpDelete("sections/scripts/{scriptId}")]
        public async Task<IActionResult> DeleteScript([FromRoute] int scriptId)
        {
            var result = await _subjectService.DeleteScript(scriptId);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("sections")]
        public async ValueTask<IActionResult> CRUDSection([FromBody] SectionDTO section)
        {
            var result = await _subjectService.CRUDSection(section);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("classes")]
        public async Task<IActionResult> CRUDClasses([FromBody] ClassDTO classDTO)
        {
            var result = await _subjectService.CRUDClass(classDTO);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("teachers")]
        public async Task<IActionResult> CRUDTeacher([FromBody] TeacherDTO teacherDTO)
        {
            var result = await _subjectService.CRUDTeacher(teacherDTO);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("students")]
        public async Task<IActionResult> CRUDStudent([FromBody] StudentDTO student)
        {
            var result = await _subjectService.CRUDStudent(student);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("students/{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid id)
        {
            var result = await _subjectService.GetStudent(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("teachers/{id}")]
        public async Task<IActionResult> GetTeacher([FromRoute] Guid id)
        {
            var result = await _subjectService.GetTeacher(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("learn")]
        public async Task<IActionResult> GetLearnData([FromQuery] Guid accountId)
        {
            var result = await _subjectService.GetMasterDataAsync(accountId);
            return Ok(result);
        }
        [HttpGet("learn/{classId}/{subjectId}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetLearnData([FromRoute] int classId, [FromRoute] Guid subjectId)
        {
            var result = await _subjectService.GetSections(subjectId, classId);
            return Ok(result);
        }
        [HttpGet("exam/{examId}")]
        public async Task<IActionResult> GetExam([FromQuery] Guid examId)
        {
            return Ok();
        }
        [HttpGet("exam/{examId}/do")]
        public async Task<IActionResult> DoExam([FromRoute] Guid examId, [FromQuery] Guid accountId)
        {
            return Ok();
        }
        //Get domain subjects
        [HttpPost("subjects")]
        public async Task<IActionResult> SubjectCRUD([FromBody] CRUDSubject subject)
        {
            var result = await _subjectService.CRUDSubject(subject);
            if (result)
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpPost("schedule")]
        public async Task<IActionResult> ScheduleCRUD([FromQuery] Guid domainId, [FromBody] ScheduleDTO scheduleDTO)
        {
            switch (scheduleDTO.Action)
            {
                case ActionDTO.GET:
                    break;
                case ActionDTO.CREATE:
                    break;
                case ActionDTO.UPDATE:
                    break;
                case ActionDTO.DELETE:
                    break;
                default:
                    break;
            }

            return Ok();
        }
        [HttpGet("subject/{id}/event")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            return Ok(await _subjectService.GetEvent(id));
        }
        [HttpPost("semester")]
        public async ValueTask<IActionResult> CRUDSemester([FromBody] SemesterDTO semesterDTO)
        {
            var result = await _subjectService.CRUDSemester(semesterDTO);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
