using Microsoft.AspNetCore.Authentication.Cookies;

namespace CookieDemo.Extensions
{
    public static class AuthenticationPipelineExtensions
    {
        public static IServiceCollection AddCookieAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(cookie =>
            {
                cookie.LoginPath = "/Account/Login";
                cookie.AccessDeniedPath = "/Account/AccessDenied";
                cookie.Cookie.Name = "MyAuthCookie";
                cookie.Cookie.HttpOnly = true;
                cookie.Cookie.SameSite = SameSiteMode.Lax;
                cookie.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                cookie.SlidingExpiration = true;
            }
            );

            services.AddAuthorization();

            return services;
        }
    }
}
