namespace Service.Core.Models.DTOs.Identities
{
    public class ComponentCreateDTO
    {
        public string ComponentName { get; set; }
        public string ComponentEndpoint { get; set; }
        public string ComponentLogo { get; set; }
        public double Price { get; set; }
    }
}
