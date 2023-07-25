using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Middlewares
{
    public class LoggingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            /* client request -> logging -> routing -> corresponding controller -> corresponding method */
            Console.WriteLine($"Incoming request: {context.Request.Protocol} {context.Request.Method} {context.Request.Path}");
            // await context.Response.WriteAsync("request should end here");
            await next(context);
        }
    }
}