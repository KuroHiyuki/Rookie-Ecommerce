namespace EcommerceWeb.Mvc.Services.Middleware
{
    public class GetTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public GetTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue("JWToken", out var token))
            {
                context.Items["access_token"] = token;
            }
            await _next(context);
        }
    }
    public static class TokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GetTokenMiddleware>();
        }
    }
}
