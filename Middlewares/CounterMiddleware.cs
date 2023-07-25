using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Services.Abstractions;

namespace WebProject.Middlewares
{
    public class CounterMiddleware : IMiddleware
    {
        private readonly ICounterService _counterService;

        public CounterMiddleware(ICounterService counterService)
        {
            _counterService = counterService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _counterService.IncreaseCounter();
            await next(context);
        }
    }
}