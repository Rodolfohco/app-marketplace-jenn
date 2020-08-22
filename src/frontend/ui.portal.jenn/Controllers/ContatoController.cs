using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ui.portal.jenn.Handler;
using ui.portal.jenn.Service;
using ui.portal.jenn.ViewComponents;

namespace ui.portal.jenn.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ILogger<ContatoController> _logger;
        private readonly IContatoService contatoService;
        private readonly ICommandResult resultado;
        public ContatoController(ILogger<ContatoController> logger, IContatoService _contatoService)
        {
            this._logger = logger;
            this.contatoService = _contatoService;
        }


    }
}
