using Application;
using Microsoft.AspNetCore.Mvc;
using Pastelaria.Resources;

namespace Pastelaria.Controllers
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
        public async Task<IList<PastelResouce>> Get()
        {
            return (await pastelService.FindAll())
                .Select(p=> new PastelResouce() { Name = p.Flavor, Ingredients = p.Ingredients, IsSweet = p.IsSweet, CurrentPrice = p.CurrentPrice})
                .ToList();
        }
    }
}