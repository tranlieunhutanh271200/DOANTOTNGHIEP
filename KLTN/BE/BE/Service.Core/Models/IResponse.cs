namespace Service.Core.Models
{
    public interface IResponse : IRequest
    {
        string Message { get; set; }
        int StatusCode { get; set; }
    }
}
