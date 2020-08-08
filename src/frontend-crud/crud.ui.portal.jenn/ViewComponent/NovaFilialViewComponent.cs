using crud.ui.portal.jenn.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn
{
    public class NovaFilialViewComponent : ViewComponent
    {
        private readonly IEmpresaService empresaService;
        public NovaFilialViewComponent(IEmpresaService _empresaService)
        {
            this.empresaService = _empresaService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
