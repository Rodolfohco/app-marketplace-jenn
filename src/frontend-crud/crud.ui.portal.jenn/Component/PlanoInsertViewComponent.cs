using api.portal.jenn.Contexto;
using api.portal.jenn.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn.Component
{
    public class PlanoInsertViewComponent : ViewComponent
    {
        private readonly DBJennContext _context;

        public PlanoInsertViewComponent(DBJennContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(Convenio convenio)
            {
            var plano = new Plano() { Convenio = convenio };


            return View(plano);
        }
    }
}
