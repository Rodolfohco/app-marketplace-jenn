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
    public class PlanoGridViewComponent : ViewComponent
    {
        private readonly DBJennContext _context;

        public PlanoGridViewComponent(DBJennContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(Convenio convenio)
        {
            var ConvenioPlano = await _context.Convenios
                .Include(c => c.Planos)
                .Where(c => c.ConvenioId == convenio.ConvenioId).FirstOrDefaultAsync();


            return View(ConvenioPlano.Planos.ToList());
        }
    }
}
