using CookieDemo.Middlewares;

namespace CookieDemo.Extensions
{
    public static class AppPipelineExtensions
    {
        public static WebApplication ConfigureAppPipeline(this WebApplication app)
        {

            app.UseHttpsRedirection();
            app.UseRouting();
            app.MapStaticAssets();

            app.UseReqLoggin();

            app.UseAuthentication();
            app.UseAuthorization();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();


            app.UseWhen(context => context.Request.Path == "/Account/Login" || context.Request.Path == "/Account/Register",
                branch =>
                {
                    branch.UseMiddleware<LastActionMiddleware>();
                });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");



            return app;
        }
    }
}
