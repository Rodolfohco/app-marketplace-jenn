using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.ViewComponents
{
    public class TopoLinkViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PesquisaViewModel model)
        {
            var MODELO = model;
            return View();
        }

    }
   
}
