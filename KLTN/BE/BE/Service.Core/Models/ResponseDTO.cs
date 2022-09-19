﻿namespace Service.Core.Models
{
    public class ResponseDTO : IResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }
}
