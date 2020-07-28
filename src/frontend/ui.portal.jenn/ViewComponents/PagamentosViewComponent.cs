using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ui.portal.jenn.Service;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.ViewComponents
{
    public class PagamentosViewComponent : ViewComponent
    {
        private readonly IProdutoService produtoService;
        public PagamentosViewComponent(IProdutoService _produtoService)
        {
            this.produtoService = _produtoService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = produtoService.BuscarPagamentos();
            return View(model);
        }
    }


}
