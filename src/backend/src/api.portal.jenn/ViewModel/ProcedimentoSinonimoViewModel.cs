using api.portal.jenn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
    public class ConsultaProcedimentoSinonimoViewModel
    {
        public int ProcedimentoSinonimoID { get; set; }

        public string Nome { get; set; }
        public Status Ativo { get; set; }

        public virtual ProcedimentoSinonimoViewModel Procedimento { get; set; }

    }





    public class NovoProcedimentoSinonimoViewModel
    {
        public string Nome { get; set; }
        public Status Ativo { get; set; }

        public int ProcedimentoID { get; set; }
    }
}