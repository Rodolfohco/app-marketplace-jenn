using api.portal.jenn.Contexto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn.Component
{
    public class PlanoProcedimentoEmpresaVinculoViewComponent : ViewComponent
    {
        private readonly DBJennContext _context;

        public PlanoProcedimentoEmpresaVinculoViewComponent(DBJennContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }

}
 