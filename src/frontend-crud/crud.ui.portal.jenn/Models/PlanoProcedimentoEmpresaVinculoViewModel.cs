using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn.Models
{
    public class PlanoProcedimentoEmpresaVinculoViewModel
    {


        public int EmpresaID { get; set; }
        public int ProcedimentoEmpresaID { get; set; }
        public int PlanoID { get; set; }
        public int ConvenioID { get; set; }

        public List<SelectListItem> Empresa { get; set; }
        public List<SelectListItem> Convenio { get; set; }
        public List<SelectListItem> Plano { get; set; }
        public List<SelectListItem> ProcedimentoEmpresa { get; set; }



    }
}
