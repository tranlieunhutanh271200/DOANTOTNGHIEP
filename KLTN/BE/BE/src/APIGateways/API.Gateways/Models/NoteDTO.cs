namespace API.Gateways.Models
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public string Color { get; set; }
    }
}