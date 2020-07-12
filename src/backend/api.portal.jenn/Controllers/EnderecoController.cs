using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.portal.jenn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly ILogger<EnderecoController> _logger;
        public EnderecoController(ILogger<EnderecoController> logger)
        {
            _logger = logger;
        }
    }
}
