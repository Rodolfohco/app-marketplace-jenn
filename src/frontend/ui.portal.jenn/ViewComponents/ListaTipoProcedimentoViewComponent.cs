using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewComponents
{
    public class ListaTipoProcedimentoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(
            string sequencia)
        {
            var valores = await Task.FromResult(
                sequencia.Split(new char[] { '|' }));
            return View(valores);
        }
    }
    

}
