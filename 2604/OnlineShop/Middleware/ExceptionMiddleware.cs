using Microsoft.AspNetCore.Http;
using System.Net;

namespace OnlineShop.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate m_Next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            m_Next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await m_Next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionWithCodeAsync(context, ex.Message);
            }
        }

        private Task HandleExceptionWithCodeAsync(HttpContext context, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(message);
        }
    }
}
