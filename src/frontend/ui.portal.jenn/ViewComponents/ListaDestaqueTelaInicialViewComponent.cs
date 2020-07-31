using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ui.portal.jenn.Service;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.ViewComponents
{
    public class ListaDestaqueTelaInicialViewComponent : ViewComponent
    {
        private readonly IProcedimentoEmpresaService procedimentoEmpresaService;

        public ListaDestaqueTelaInicialViewComponent(IProcedimentoEmpresaService _procedimentoEmpresaService)
        {
            this.procedimentoEmpresaService = _procedimentoEmpresaService;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
             var  procedimento = await this.procedimentoEmpresaService.ListaProcedimentoEmpresa();

            if (procedimento != null && procedimento.Any())
                return View(procedimento.Where(x => x.destaque.HasValue ? x.destaque > 0 : false).ToList());

            else
                return View(Enumerable.Empty<ProcedimentoEmpresaViewModel>());

        }

    }
    
}
