using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ExternalizeApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalizeController: ControllerBase
    {
        public IConfiguration Configuration { get; }
        public ExternalizeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public Dictionary<string,string> Get()
        {
            return Configuration
                .GetSection("Configurations")
                .GetChildren()
                .ToDictionary(a => a.Key, a => a.Value);
        }
    }
}
