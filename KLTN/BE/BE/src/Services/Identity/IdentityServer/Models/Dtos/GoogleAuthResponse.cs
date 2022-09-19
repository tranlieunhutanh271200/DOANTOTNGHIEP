namespace IdentityServer.Models.Dtos
{
    public class GoogleAuthResponse : IAuthResponse
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
    }
}
