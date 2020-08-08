using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn.Models
{
    public class PagamentoProcedimentoEmpresaViewModel
    {
        public int PagamentoProcedimentoEmpresaID { get; set; }

        public virtual PagamentoViewModel Pagamento { get; set; }
        public virtual ConsultaProcedimentoEmpresaViewModel ProcedimentoEmpresa { get; set; }
    }
    public class ConsultaPagamentoProcedimentoEmpresaViewModel
    {
        public int PagamentoProcedimentoEmpresaID { get; set; }

        public virtual PagamentoViewModel Pagamento { get; set; }
     
    }


    public class NovoPagamentoProcedimentoEmpresaViewModel
    {
 
        public virtual PagamentoViewModel Pagamento { get; set; }
        public virtual int ProcedimentoEmpresaID { get; set; }
    }
}
