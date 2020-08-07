using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
    public class ConsultaAgendaViewModel
    {
        public int AgendaID { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
        public DateTime Hora { get; set; }
        public DateTime DataVigencia { get; set; }

        public ProcedimentoEmpresaViewModel ProcedimentoEmpresa { get; set; }
    }

    public class NovoAgendaViewModel
    {
        public int Mes { get; set; }
        public int Dia { get; set; }
        public DateTime Hora { get; set; }
        public DateTime DataVigencia { get; set; }
    }


}
