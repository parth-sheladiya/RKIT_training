using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingDemo : ControllerBase
    {
        private readonly ILogger<LoggingDemo> _logger;

        /// <summary>
        /// inject Ilogger in ctor
        /// </summary>
        /// <param name="logger"></param>
        public LoggingDemo(ILogger<LoggingDemo> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// call different level of log
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogTrace("trace log");
            _logger.LogDebug("log debug");
            _logger.LogInformation("information log");
            _logger.LogWarning("warning log");
            _logger.LogError("error log");
            _logger.LogCritical("critical log");
            
            return Ok("this is all responce");
        }
    }
}
