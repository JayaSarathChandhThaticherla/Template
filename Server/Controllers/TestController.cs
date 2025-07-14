using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }
        [HttpGet("test1")]
        public IActionResult Get()
        {
            _logger.LogInformation("Test endpoint hit");
            _logger.LogError("This is a test error log");
            return Ok("Test successful");
        }

        [HttpGet("test2")]
        public IActionResult Test2()
        {
            _logger.LogInformation("Test2 endpoint hit");
            _logger.LogError("This is a test2 error log")
            return Ok("Test2 successful");
        }
    }
}
