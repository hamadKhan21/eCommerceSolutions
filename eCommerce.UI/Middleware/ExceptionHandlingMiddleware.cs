using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace eCommerce.UI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch(System.Exception ex)
            {
                httpContext.Response.StatusCode = 500;
                _logger.LogError($"Message:{ex.Message},Type:{ex.GetType().ToString()}");

                if(ex.InnerException is not null)
                {
                    _logger.LogError($"Inner Exception:{ex.InnerException.Message},Type:{ex.GetType().ToString()}");

                    await httpContext.Response.WriteAsJsonAsync(
                        new
                    {
                        Message=ex.Message,
                        Type=ex.InnerException.GetType().ToString()

                    }
                        );

                }

            }

            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
