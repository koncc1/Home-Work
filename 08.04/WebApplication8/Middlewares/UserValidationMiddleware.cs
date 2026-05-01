namespace WebApplication8.Middlewares
{
    public class UserValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public UserValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/User/Save" && context.Request.Method == "POST")
            {
                var form = await context.Request.ReadFormAsync();

                string name = form["Name"].ToString();
                string login = form["Login"].ToString();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(login))
                {
                    await context.Response.WriteAsync("Name or login is empty");
                    return;
                }
            }

            await _next(context);

        }

    }
}
