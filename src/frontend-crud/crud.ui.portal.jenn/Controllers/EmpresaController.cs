using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud.ui.portal.jenn.Models;
using crud.ui.portal.jenn.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace crud.ui.portal.jenn.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService contexto;
        private readonly ILogger<EmpresaController> _logger;

        public EmpresaController(ILogger<EmpresaController> logger, IEmpresaService _contexto)
        {
            contexto = _contexto;
            _logger = logger;


        }


        public async Task<IActionResult> Lista()
        {
            var empresas = await contexto.Selecionar();
            var objEmpresa = JsonConvert.DeserializeObject<IEnumerable<EmpresaViewModel>>(empresas.Data.ToString());

            
            
            return View(objEmpresa);
        }

        
        public async Task<IActionResult> Novo()
        {
            var empresas = await contexto.Selecionar();
            var objEmpresa = JsonConvert.DeserializeObject<IEnumerable<EmpresaViewModel>>(empresas.Data.ToString());

                var select = objEmpresa.ToList().Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.EmpresaID.ToString() }).ToList();

            select.Insert(0, new SelectListItem("Selecione uma Empresa", ""));

         ViewBag.EmpresaObjeto = select;




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Novo(NovaEmpresaViewModel model)
        {
            return RedirectToAction("Lista");
        }

        public IActionResult Index()
        {


            return View();
        }
    }
}
