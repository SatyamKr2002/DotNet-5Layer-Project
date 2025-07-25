﻿namespace EMS.Model.ViewModel
{ 
    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public Response(int statusCode, string message, object? data = null)
        {
                StatusCode = statusCode;
                Message = message;
                Data = data;
        }
    }
}
