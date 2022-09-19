using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Core.Models.Identities;
using Service.Core.Persistence;
using Service.Core.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Persistence.Repositories
{
    public class AccountRepository : AsyncRepository<Account, Guid>, IAccountRepository
    {
        public AccountRepository(IdentityDbContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public async ValueTask<bool> CheckAccountExist(string domain, string username)
        {
            return await _dbSet.AnyAsync(x => x.Domain.Abbreviation.ToLower().Equals(domain.ToLower()) && x.Username.ToLower().Equals(username.ToLower()));
        }

        public async ValueTask<RefreshToken> GenerateRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.Now.AddDays(7),
                    Created = DateTime.Now,
                    CreatedByIp = ipAddress
                };
            }
        }

        public async ValueTask<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async ValueTask<string> GenerateToken(string domain, string username, string password)
        {
            var queryAccount = await _dbSet.Where(acc => acc.Domain.Abbreviation.ToLower() == domain.ToLower() && acc.Username == username).Include(inc => inc.Role).AsNoTracking().FirstOrDefaultAsync();
            if (queryAccount == null)
            {
                return string.Empty;
            }
            if (!CryptoUtil.MD5.CompareHash(password, queryAccount.Salt, queryAccount.HashPassword))
            {
                return string.Empty;
            }
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, queryAccount.Id.ToString()),
                new Claim(ClaimTypes.AuthenticationMethod, domain.ToLower()),
                new Claim(ClaimTypes.Name, queryAccount.Username),
                new Claim(ClaimTypes.Email, queryAccount.Email),
                new Claim(ClaimTypes.Role, queryAccount.Role.Id.ToString()),
            };

            ClaimsIdentity claimIdentity = new ClaimsIdentity(claims);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:TokenSecret").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.Add(TimeSpan.FromSeconds(int.Parse(_configuration.GetSection("JwtSettings:TokenLifetime").Value))),
                SigningCredentials = credentials,
                Issuer = _configuration.GetSection("JwtSettings:Issuer").Value,
                Subject = claimIdentity
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);
        }

        public async ValueTask<string> GenerateToken(string domain, string username)
        {
            var queryAccount = await _dbSet.Where(acc => acc.Domain.Abbreviation.ToLower() == domain.ToLower() && acc.Username == username).Include(inc => inc.Role).AsNoTracking().FirstOrDefaultAsync();
            if (queryAccount == null)
            {
                return string.Empty;
            }
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, queryAccount.Id.ToString()),
                new Claim(ClaimTypes.AuthenticationMethod, domain.ToLower()),
                new Claim(ClaimTypes.Name, queryAccount.Username),
                new Claim(ClaimTypes.Email, queryAccount.Email),
                new Claim(ClaimTypes.Role, queryAccount.Role.Id.ToString()),
            };

            ClaimsIdentity claimIdentity = new ClaimsIdentity(claims);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:TokenSecret").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.Add(TimeSpan.FromSeconds(int.Parse(_configuration.GetSection("JwtSettings:TokenLifetime").Value))),
                SigningCredentials = credentials,
                Issuer = _configuration.GetSection("JwtSettings:Issuer").Value,
                Subject = claimIdentity
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);
        }

        public async ValueTask<Account> GetAccount(Guid accountId)
        {
            return await GetEntity(x => x.Id == accountId, x => x.Role);
        }

        public async ValueTask<Account> GetAccount(string domain, string username, string refreshToken)
        {
            return await GetEntity(x => x.Domain.Abbreviation.ToLower().Equals(domain.ToLower()) && x.Username.ToLower().Equals(username.ToLower()) && x.RefreshToken == refreshToken, x => x.Role);
        }

        public async ValueTask<Account> GetAccount(string domain, string username)
        {
            return await GetEntity(x => x.Domain.Abbreviation.ToLower().Equals(domain.ToLower()) && x.Username.ToLower().Equals(username.ToLower()), x => x.Role);
        }

        public async ValueTask<bool> LockAccount(string email, TimeSpan duration)
        {
            var account = await _dbSet.FirstOrDefaultAsync(acc => acc.Email == email);
            if (account == null)
            {
                return false;
            }
            account.IsLocked = true;
            account.LastLockUntil = DateTime.Now + duration;
            var result = await UpdateEntity(account.Id, account);
            return result != null;
        }

        public ValueTask<Account> RegisterAccount(string username, string roleId)
        {
            throw new NotImplementedException();
        }
    }
}
