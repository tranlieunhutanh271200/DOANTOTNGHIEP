namespace API.Gateways.Models
{
    public class SemesterDTO : BaseDTO
    {
        public int Id { get; set; }
        public string SemesterName { get; set; }
        public string SemesterStart { get; set; }
        public string SemesterEnd { get; set; }
        public int Year { get; set; }
    }
}
