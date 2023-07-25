using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProject.Services.Abstractions;

namespace WebProject.Controllers
{
    [ApiController]
    [Route("api/v1/counter")]
    public class CounterController: ControllerBase
    {
        private readonly ICounterService _counterService;

        public CounterController([FromServices] ICounterService counterService)
        {
            _counterService = counterService;
        }

        [HttpGet("increase")]
        public ActionResult IncreaseCounter()
        {
            var counter1 = _counterService.IncreaseCounter(); // 1 new instance if transient
            var counter2 = _counterService.IncreaseCounter(); // 1 new instance if transient
            var counter3 = _counterService.IncreaseCounter();
            return Ok(new { counter1, counter2, counter3 });
        }
    }
}