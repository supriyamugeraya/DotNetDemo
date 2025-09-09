using System.Net;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace DotNetDemo.API.Middlewares
{
    public class ExceptionhandlerMiddleware
    {
        private readonly ILogger<ExceptionhandlerMiddleware> logger;

        public ExceptionhandlerMiddleware(ILogger<ExceptionhandlerMiddleware> logger,
            RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        private readonly RequestDelegate next;

        
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                // Log This Exception
                logger.LogError(ex,$"{errorId}:{ ex.Message}");

                //Return a custom Error Response
                httpContext.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType= "application/json";

                var eeror = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong : we are looking into resolving this."
                };
                
                await httpContext.Response.WriteAsJsonAsync(eeror);
               

            }
        }
    }
}
