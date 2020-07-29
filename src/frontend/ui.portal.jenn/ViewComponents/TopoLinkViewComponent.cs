using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.ViewComponents
{
    public class TopoLinkViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
 
            PesquisaViewModel model =   JsonConvert.DeserializeObject<PesquisaViewModel>(HttpContext.Session.GetString("filtroPesquisa"));

            if (model != null)
                return View(model);
            else
                return View(new PesquisaViewModel());
        }

    }
   
}
