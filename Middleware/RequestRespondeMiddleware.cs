using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Middleware
{
    public class RequestRespondeMiddleware
    {
        private readonly RequestDelegate next;
        public ILogger<RequestRespondeMiddleware> Logger { get; }

        public RequestRespondeMiddleware(RequestDelegate requestDelegate,ILogger<RequestRespondeMiddleware> _logger)
        {
            next = requestDelegate;
            Logger = _logger;
        }



        public async Task Invoke(HttpContext httpContext)
        {

           

            // Request  Post Method         

            Logger.LogInformation($"QueryString:{httpContext.Request.QueryString}");

            Logger.LogInformation($"Request Method:{httpContext.Request.Method}");

            Logger.LogInformation($"Request Content Type:{httpContext.Request.ContentType}");

            Logger.LogInformation($"Request Content Length:{httpContext.Request.ContentLength}");


  


            await next.Invoke(httpContext); // Response bu satırda oluşuyor



            Logger.LogInformation($"Response Content Length:{httpContext.Response.ContentType}");
            Logger.LogInformation($"Response Content Type:{httpContext.Response.ContentLength}");
     

            // response

            
        }
    }
}
