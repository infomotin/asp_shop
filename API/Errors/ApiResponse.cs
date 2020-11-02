using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            
            // return switch (statusCode)
            // {
            //     case 400:
                    


            //     default:
            // }
            return statusCode switch 
            {
                400 => "A bad request to make you ",
                401 => "401",
                404 => "Not Found Vaolo Kore Khug ??",
                500 => "Server Error",
                _ => null,
                
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}