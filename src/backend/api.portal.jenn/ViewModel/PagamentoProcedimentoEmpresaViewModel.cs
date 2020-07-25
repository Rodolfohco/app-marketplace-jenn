using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
    public class PagamentoProcedimentoEmpresaViewModel
    {
        public int PagamentoProcedimentoEmpresaID { get; set; }

        public virtual PagamentoViewModel Pagamento { get; set; }
        public virtual ProcedimentoEmpresaViewModel ProcedimentoEmpresa { get; set; }
    }
}
