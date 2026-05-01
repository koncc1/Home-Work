namespace CookieDemo.Middlewares
{
    public class ReqLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ReqLoggingMiddleware> logger;

        public ReqLoggingMiddleware(RequestDelegate next, ILogger<ReqLoggingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            logger.LogInformation("Request: {method} {path}", context.Request.Method, context.Request.Path);
            await next(context);
        }
    }
}
