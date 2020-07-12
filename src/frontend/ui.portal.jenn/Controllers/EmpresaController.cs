using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ui.portal.jenn.Service;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService empresaService;
        private readonly ILogger<EmpresaController> logger;
        public EmpresaController(
            ILogger<EmpresaController> _logger,
            IEmpresaService _empresaService)
        {
            this.logger = _logger;
            this.empresaService = _empresaService;
        }

        // GET: EmpresaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmpresaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpresaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpresaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nova(EmpresaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empresaService.Novo(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(ModelState.Values);
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpresaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpresaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpresaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpresaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
