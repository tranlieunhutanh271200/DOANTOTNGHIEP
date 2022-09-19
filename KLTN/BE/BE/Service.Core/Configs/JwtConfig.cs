namespace Service.Core.Configs
{
    public class JwtConfig
    {
        public string TokenSecret { get; set; }
        public int TokenLifetime { get; set; }
    }
}
