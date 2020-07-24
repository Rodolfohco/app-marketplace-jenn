using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
    public class PlanoViewModel
    {
        public int PlanoID { get; set; }

        public string Nome { get; set; }

       public ConvenioViewModel Convenio { get; set; }
    }





    public class PlanoProcedimentoEmpresaViewModel
    {
        public int PlanoProcedimentoEmpresaID { get; set; }
       
        public int ProcedimentoEmpresaID { get; set; }
        public virtual ProcedimentoEmpresaViewModel ProcedimentoEmpresa { get; set; }

        public int PlanoID { get; set; }
        public virtual PlanoViewModel Plano { get; set; }

    }
}