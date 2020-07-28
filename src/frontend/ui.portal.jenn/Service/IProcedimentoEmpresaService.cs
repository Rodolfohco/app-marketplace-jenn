using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Service
{
    public interface IProcedimentoEmpresaService
    {
        CommandInput Converter(HttpMethod Method, string Controle = null, ProcedimentoEmpresaViewModel model = null);
        Task<IEnumerable<ProcedimentoEmpresaViewModel>> ListaProcedimentoEmpresa();
        Task<ProcedimentoEmpresaViewModel> DetalhaProcedimentoEmpresa(int ProcedimentoID);
    }
}
