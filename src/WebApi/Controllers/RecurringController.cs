using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecurringController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            RecurringJob.AddOrUpdate(
                "RecurringJob-Minutely",
                () => Console.WriteLine(DateTime.Now.ToString()),
                Cron.Minutely);
            return Ok("Was job ordered successfully");
        }
    }
}