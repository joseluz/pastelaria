using Microsoft.AspNetCore.Mvc;

namespace Pastelaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastelController : ControllerBase
    {
        private readonly ILogger<PastelController> _logger;

        public PastelController(ILogger<PastelController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
        }
    }
}