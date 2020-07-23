using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.ViewComponents
{
    public class ListaTipoProcedimentoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<TipoProcedimentoViewModel> model = new List<TipoProcedimentoViewModel>();
            model.Add(new TipoProcedimentoViewModel() { TipoProcedimentoID = 1, Nome = "Check-up" });

            model.Add(new TipoProcedimentoViewModel() { TipoProcedimentoID = 1, Nome = "Check-up" });

             
            return View(model);
        }
    }
    

}
