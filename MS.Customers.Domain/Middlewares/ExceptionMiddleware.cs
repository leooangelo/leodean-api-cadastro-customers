using MS.Customer.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MS.Customer.Domain.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //httpContext.Request.EnableBuffering();

            //var reader = new StreamReader(httpContext.Request.Body);
            //var body = await reader.ReadToEndAsync();

            //var jsonBody = JsonConvert.SerializeObject(body);
            //var jsonHeaders = JsonConvert.SerializeObject(httpContext.Request.Headers);

            //var dict = new Dictionary<string, object>();
            //dict.Add("path", httpContext.Request.Path);
            //dict.Add("body", jsonBody);
            //dict.Add("headers", jsonHeaders);

            //httpContext.Request.Body.Position = 0;

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case DomainException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(ex));
                    break;

                case UnauthorizedAccessException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(ex));
                    break;

                case DatabaseException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(ex));
                    break;

                case Exception ex:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(ex));
                    break;
            };
        }
    }
}