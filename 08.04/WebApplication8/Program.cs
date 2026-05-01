using System.Diagnostics;
using WebApplication8.Middlewares;

namespace WebApplication8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.Use(async (context,next) =>
            {
                if (context.Request.Path == "/User/Save" && context.Request.Method == "POST")
                {
                    var form = await context.Request.ReadFormAsync();
                    var username = form["Name"].ToString();
                    if (string.IsNullOrEmpty(username))
                    {
                        await context.Response.WriteAsync("Name is empty");
                        return;
                    }
                }
                await next();
                //var pass = context.Request.Query["pass"].ToString();
                //if(pass != "qwe")
                //{
                //    await context.Response.WriteAsync("Wrong pass");
                //    return;
                //}
                //Console.WriteLine($"Access ok");
                //await next();
                ////await context.Response.WriteAsync("Stopped in middleware");
                ////Console.WriteLine($"Middleware start");
                ////Console.WriteLine($"Requst path:{context.Request.Path}");
                ////await next();

                ////Console.WriteLine($"Middleware end");
                //var watch = Stopwatch.StartNew();
                //Console.WriteLine($"Request started {context.Request.Path}");
                //await next();
                //watch.Stop();
                //Console.WriteLine($"Time: {watch.ElapsedMilliseconds}");
            });

            app.UseMiddleware<UserValidationMiddleware>();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
