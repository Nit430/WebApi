using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApi
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello from File1\n");
            await next(context);
            await context.Response.WriteAsync("Hello from File2\n");
        }
    }
}
