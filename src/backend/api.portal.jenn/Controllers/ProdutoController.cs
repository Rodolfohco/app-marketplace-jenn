using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.portal.jenn.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace api.portal.jenn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMemoryCache cache;
        private readonly ILogger<ProdutoController> logger;
        private readonly IProdutoBusiness repositorio;
        public ProdutoController(ILogger<ProdutoController> _logger, IMemoryCache _cache, IProdutoBusiness _repositorio)
        {
            this.logger = _logger;
            this.repositorio = _repositorio;
            this.cache = _cache;
        }
    }
}
