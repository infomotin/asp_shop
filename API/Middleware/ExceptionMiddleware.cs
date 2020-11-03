using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Net;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        //RequestDelegate function that can process an HTTP request.
        // Returns:
        // A task that represents the completion of request processing.
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }
        //HttpContext Encapsulates all HTTP-specific information about an individual HTTP request. 
        //Awaited task returns no value
        public async Task InvokeAsync(HttpContext context){
            try
            {
                await _next(context);
                
            }
            catch (System.Exception ex)
            {
                
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //ApiException is an have peremitter with value initialize ing 
                var response = _env.IsDevelopment() ? new ApiException((int)HttpStatusCode.InternalServerError,ex.Message,ex.StackTrace.ToString());
                
            }
        }
    }
}