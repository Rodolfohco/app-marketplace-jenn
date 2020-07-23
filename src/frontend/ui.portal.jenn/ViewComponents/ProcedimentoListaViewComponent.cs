using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.ViewComponents
{

    public class ProcedimentoListaViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(
            PesquisaViewModel model)
        {
            //var valores = await Task.FromResult(sequencia.Split(new char[] { '|' }));
            return View(model);
        }
    }

    
}
