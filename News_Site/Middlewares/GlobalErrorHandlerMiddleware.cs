using Microsoft.AspNetCore.Http.HttpResults;

namespace News_Site.Middlewares
{
    public class GlobalErrorHandlerMiddleware
    {
        private RequestDelegate _next;
        public GlobalErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                
                 context.Response.Redirect("/Home/Error");
            }
        }
    }
}
