using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.ViewComponents
{
    
    public class TopoControleLinkViewComponent : ViewComponent
    {


        private readonly IHttpContextAccessor _accessor;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
        public TopoControleLinkViewComponent(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            InformacaoTopo model = new InformacaoTopo();
            model.Logado = false;
            
            if (GetClaimsIdentity().FirstOrDefault() != null)
            {
                List<string> lst = _accessor.HttpContext.User.Identity.Name.ToString().Split(" ").ToList();


                model.Nome = lst.FirstOrDefault();
                model.Email = GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;
                model.Logado = true;
            }
         

            return View(model);
        }       

   }
}
