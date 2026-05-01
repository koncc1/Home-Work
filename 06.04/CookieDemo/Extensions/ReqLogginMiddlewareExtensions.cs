using CookieDemo.Middlewares;

namespace CookieDemo.Extensions
{
    public static class ReqLogginMiddlewareExtensions
    {
        public static IApplicationBuilder UseReqLoggin(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ReqLoggingMiddleware>();
        }
    }
}
