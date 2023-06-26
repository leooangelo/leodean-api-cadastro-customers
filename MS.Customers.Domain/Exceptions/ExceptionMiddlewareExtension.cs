using MS.Customer.Domain.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace MS.Customer.Domain.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
