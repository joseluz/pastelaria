using Microsoft.AspNetCore.Mvc;
using Pastels.Api.Resources;
using Pastels.Application;

namespace Pastels.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PastelController : ControllerBase
    {
        private readonly ILogger<PastelController> _logger;
        private readonly IPastelService pastelService;

        public PastelController(ILogger<PastelController> logger,
            IPastelService pastelService)
        {
            _logger = logger;
            this.pastelService = pastelService;
        }

        [HttpGet]
        public async Task<IEnumerable<Pastel>> Get()
        {
            return await pastelService.FindAll();
        }
    }
}