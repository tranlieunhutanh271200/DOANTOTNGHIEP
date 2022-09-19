using Service.Core.Models.DTOs.Identities;

namespace Service.Core.Models.DTOs.Gateway
{
    public class AuthenticateDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiredIn { get; set; }
        public AccountDTO Account { get; set; }
        public object Data { get; set; }
    }
}
