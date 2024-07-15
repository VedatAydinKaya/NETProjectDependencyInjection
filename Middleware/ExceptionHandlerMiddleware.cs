namespace Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ILogger<ExceptionHandlerMiddleware> Logger { get; }

        public ExceptionHandlerMiddleware(RequestDelegate _next,ILogger<ExceptionHandlerMiddleware> _logger)
        {
            next = _next;
            Logger = _logger;
        }

        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }

      
        }
    }
}
