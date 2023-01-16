using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FireAndForgetController : ControllerBase
    {
        public FireAndForgetController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            var jobId = BackgroundJob.Enqueue(() => SendMail(DateTime.Now.ToString()));
            return Ok($"Great! The job {jobId} has been completed. The mail has been sent to the user.");
        }

        public void SendMail(string message)
        {
            Console.WriteLine($"This is Fire-And-Forget Job: This is message {message} ");
        }
    }
}