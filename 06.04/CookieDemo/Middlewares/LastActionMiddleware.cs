namespace CookieDemo.Middlewares
{
    public class LastActionMiddleware
    {
        private readonly RequestDelegate _next;

        public LastActionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "POST")
            {
                var form = await context.Request.ReadFormAsync();

                string login = form["Login"];
                string password = form["Password"];

                if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                {
                    await context.Response.WriteAsync("Field error");
                    return;
                }

                if (password.Length < 6)
                {
                    await context.Response.WriteAsync("unccorect password");
                    return;
                }

                if (context.Request.Path == "/Account/Login")
                {
                    context.Response.Cookies.Append("LastAction", "Login");
                }

                if (context.Request.Path == "/Account/Register")
                {
                    context.Response.Cookies.Append("LastAction", "Register");
                }
            }

            await _next(context);
        }
    }
}