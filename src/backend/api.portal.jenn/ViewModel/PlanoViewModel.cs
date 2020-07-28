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

        public ConsultaConvenioViewModel Convenio { get; set; }
    }



    public class ConsultaPlanoViewModel
    {
        public int PlanoID { get; set; }

        public string Nome { get; set; }

 
    }


    //public class PlanoProcedimentoEmpresaViewModel
    //{
    //    public int PlanoProcedimentoEmpresaID { get; set; }
    //    public virtual ProcedimentoEmpresaViewModel ProcedimentoEmpresa { get; set; }
    //    public virtual PlanoViewModel Plano { get; set; }

    //}

    public class NovoPlanoProcedimentoEmpresaViewModel
    {
        public virtual PlanoViewModel Plano { get; set; }
        public virtual ConsultaProcedimentoEmpresaViewModel ProcedimentoEmpresa { get; set; }

    }


    public class PlanoProcedimentoEmpresaViewModel
    {
        public virtual PlanoViewModel Plano { get; set; }

        public int ProcedimentoEmpresaID { get; set; }

    }
}