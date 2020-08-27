using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.ViewComponents
{

    public class ProcedimentoListaViewComponent : ViewComponent
    {

        private readonly IConfiguration _configuration;
        public ProcedimentoListaViewComponent(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            PesquisaViewModel model)
        {

            model.UrlImagem = string.Format(this._configuration.GetValue<string>("urlImagem"), model.UrlImagem);
            return View(model);
        }
    }

    
}



