
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;

namespace Service.Core.Models.Http
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
        public Pagination Pagination { get; set; }
        public Response(int statusCode, string msg, T data, Pagination pagination = null)
        {
            StatusCode = statusCode;
            Message = msg;
            Data = JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            Pagination = pagination;
        }
    }
    public class Pagination
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; } = 0;
        public int PageSize { get; set; } = 0;
    }
    public static class HttpResponse
    {
        public static U OK<T, U>(Func<Response<T>, U> action, string msg, T data, Pagination pagination) => action(new Response<T>((int)HttpStatusCode.OK, msg, data, pagination));
        public static Response<T> BadRequest<T>(string msg, T data) => new Response<T>((int)HttpStatusCode.BadRequest, msg, data);
        public static Response<T> Timeout<T>(string msg, T data) => new Response<T>((int)HttpStatusCode.RequestTimeout, msg, data, null);
        public static Response<T> Unauthorized<T>(string msg, T data) => new Response<T>((int)HttpStatusCode.Unauthorized, msg, data, null);
    }
}
