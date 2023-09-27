using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace demo_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly ILogger<ConfigController> _logger;
        private readonly SecretProvider _secretProvider;

        public ConfigController(ILogger<ConfigController> logger, IOptions<SecretProvider> options)
        {
            _logger = logger;
            _secretProvider = options.Value;
        }

        [HttpGet(Name = "Config")]
        public SecretProvider GetConfig()
        {
            return _secretProvider;
        }
    }
}