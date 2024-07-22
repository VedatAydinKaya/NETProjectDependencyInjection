using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using static System.Net.Mime.MediaTypeNames;

namespace Middleware
{
    public class RequestRespondeMiddleware
    {
        private readonly RequestDelegate next;
        public ILogger<RequestRespondeMiddleware> Logger { get; }

        public RequestRespondeMiddleware(RequestDelegate requestDelegate, ILogger<RequestRespondeMiddleware> _logger)
        {
            next = requestDelegate;
            Logger = _logger;
        }



        public async Task Invoke(HttpContext httpContext)
        {



            var originalBodyStream = httpContext.Response.Body;
          
            #region Request

            //Logger.LogInformation($"QueryString:{httpContext.Request.QueryString}");

            //Logger.LogInformation($"Request Method:{httpContext.Request.Method}");

            //Logger.LogInformation($"Request Content Type:{httpContext.Request.ContentType}");

            //Logger.LogInformation($"Request Content Length:{httpContext.Request.ContentLength}");

            //Logger.LogWarning($"Host Name:  {httpContext.Request.Host.Value}");

            #endregion Request

            // reading Request Body with Post Method

            MemoryStream requestBody = new MemoryStream();
            await httpContext.Request.Body.CopyToAsync(requestBody);
            requestBody.Seek(0, SeekOrigin.Begin);
            String requestBodyText= await new StreamReader(requestBody).ReadToEndAsync();
            requestBody.Seek(0, SeekOrigin.Begin);

            //Logger.LogInformation($"Request Body:{requestBodyText}");



            #region response

            //Logger.LogInformation($"Response Content Length:{httpContext.Response.ContentType}");
            //Logger.LogInformation($"Response Content Type:{httpContext.Response.ContentLength}");

            var tempStream = new MemoryStream(); // readable stream that we created for 
            httpContext.Response.Body = tempStream;

            await next.Invoke(httpContext);         // calling actual action or endpoint

            //tempStream.Seek(0, SeekOrigin.Begin );
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await new StreamReader(httpContext.Response.Body, Encoding.UTF8).ReadToEndAsync();
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

            //var json = await response.Content.ReadAsStringAsync();
            var result = JsonObject.Parse(responseBodyText); // 



            await httpContext.Response.Body.CopyToAsync(originalBodyStream);

            Logger.LogInformation($"Request : {requestBodyText}");
            Logger.LogInformation($"Response: {result}");


            #endregion response






        }
    }
}
