using IdentityServer.Models.Dtos;
using IdentityServer.Persistence;
using IdentityServer.Persistence.Repositories;
using IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service.Core.Models.DTOs.Gateway;
using Service.Core.Persistence.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        private readonly IdentityDbContext _db;
        public IdentityController(IUnitOfWork unitOfWork, IAccountService accountService, IConfiguration configuration, IdentityDbContext db)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = unitOfWork.GetRequiredRepository<IAccountRepository, AccountRepository>();
            _accountService = accountService;
            _configuration = configuration;
            _db = db;
        }
        #region Check Hashing Function
        //[HttpGet("ping")]
        //public async Task<IActionResult> Ping(string password)
        //{
        //    CryptoUtil.MD5.Hash(password, out var salt, out var hashed);

        //    return Ok(new {salt = salt, hashed = hashed});
        //}
        //[HttpGet("check")]
        //public async Task<IActionResult> Check(string password, string salt, string hashed)
        //{
        //    return Ok(CryptoUtil.MD5.CompareHash(password, salt, hashed));
        //}
        #endregion

        #region Check Cache
        //[HttpGet("SetCache")]
        //public async Task<IActionResult> SetCache(string key, string value)
        //{
        //    InMemoryCache.Instance.Set(key,value, TimeSpan.FromSeconds(30));
        //    return Ok();
        //}
        //[HttpGet("GetCache")]
        //public async Task<IActionResult> GetCache(string key)
        //{
        //    return Ok(InMemoryCache.Instance.Get<string>(key));
        //}
        #endregion
        [AllowAnonymous]
        [Authorize]
        [HttpGet("auth")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public IActionResult AuthUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok();
            }
            return Unauthorized();
        }
        [HttpGet("{domainId}/{accountId}")]
        public async Task<IActionResult> GetAccountAsync(Guid domainId, Guid accountId)
        {
            var result = await _accountService.GetAccount(domainId, accountId);
            return result.Match<IActionResult>(Ok, NotFound);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountRegisterDTO accountRegisterDTO)
        {
            var result = await _accountService.CreateAccount(accountRegisterDTO.Id, accountRegisterDTO.Email, accountRegisterDTO.Username, accountRegisterDTO.Password, accountRegisterDTO.DomainId);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("login")]
        [AllowAnonymous]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(TokenResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Token([FromQuery] string domain, [FromQuery] string username, [FromQuery] string password)
        {
            _unitOfWork.CreateTransaction();
            try
            {
                var createToken = await _accountRepository.GenerateToken(domain, username, password);
                if (string.IsNullOrEmpty(createToken))
                {
                    return Unauthorized();
                }
                var refreshToken = await _accountRepository.GenerateRefreshToken();
                var account = await _accountService.GetAccount(domain, username);
                await _accountService.UpdateRefreshToken(account.Id, refreshToken);
                AuthenticateDTO authenticateDTO = new AuthenticateDTO
                {
                    Token = createToken,
                    ExpiredIn = int.Parse(_configuration.GetValue<string>("JwtSettings:TokenLifeTime")),
                    Account = account,
                    RefreshToken = refreshToken
                };
                return Ok(authenticateDTO);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
        [HttpPost("refresh-token")]
        [AllowAnonymous]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(TokenResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request is null");
            }
            var account = await _accountRepository.GetEntity(x => x.Id == request.AccountId, inc => inc.Domain);
            if (account == null)
            {
                return BadRequest();
            }
            string token = await _accountRepository.GenerateToken(account.Domain.Abbreviation, account.Username);
            string refreshToken = await _accountRepository.GenerateRefreshToken();
            account.RefreshToken = refreshToken;
            await _db.SaveChangesAsync();
            AuthenticateDTO authenticateDTO = new AuthenticateDTO
            {
                Token = token,
                ExpiredIn = int.Parse(_configuration.GetValue<string>("JwtSettings:TokenLifeTime")),
                RefreshToken = refreshToken
            };
            return Ok(authenticateDTO);
        }
        [Authorize]
        [HttpPost("revoke")]
        public async Task<IActionResult> Revoke([FromQuery] Guid domainId)
        {
            var user = User.Identity.Name;
            var account = await _db.Accounts.Where(x => x.Username == user && x.DomainId == domainId).FirstOrDefaultAsync();
            if (account == null)
            {
                return BadRequest();
            }
            account.RefreshToken = null;
            await _db.SaveChangesAsync();
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("social")]
        [ProducesDefaultResponseType]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> SocialAuth()
        {
            return Ok("Authorized");
        }
        [HttpPut("accounts/{id}")]
        public async Task<IActionResult> EditAccount()
        {
            return Ok();
        }
        [HttpDelete("accounts/{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] Guid id)
        {
            var account = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            _db.Accounts.Remove(account);
            if (await _db.SaveChangesAsync() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("accounts")]
        public async Task<IActionResult> GetAccounts([FromQuery] Guid domainId)
        {
            var accounts = await _accountService.GetAccountsAsync(domainId);
            return Ok(accounts);
        }
    }
}
