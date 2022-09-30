using Microsoft.AspNetCore.Mvc;
using Pastelaria.Resources;

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
        public IEnumerable<PastelResouce> Get()
        {
            return new List<PastelResouce>();
        }
    }
}