namespace Service.Core.Models.DTOs.Identities
{
    public class AccountLoginDTO
    {
        public AccountDTO Account { get; set; }
        public string Token { get; set; }
        public int TokenExpired { get; set; }
    }
}
