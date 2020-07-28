using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewComponents
{
    public class FooterParte2ViewComponent : ViewComponent
    {
     
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View( );
        }
    }

    public class FooterParte1ViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
