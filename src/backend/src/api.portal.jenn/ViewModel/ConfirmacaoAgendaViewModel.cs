using database.portal.jenn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{

    public class ConsultaConfirmacaoAgendaViewModel : ConfirmacaoAgendaViewModel
    {
        public int ConfirmacaoAgendaID { get; set; }
    }
    public class ConfirmacaoAgendaViewModel
    {

        public string CarteirinhaConvenio { get; set; }

        public bool contraste { get; set; }


        public bool PacienteTitular { get; set; }


        public float Peso { get; set; }

        public float Altura { get; set; }


        public string AlergiaReacoes { get; set; }
        public int PlanoID { get; set; }
        public int AgendaID { get; set; }
        public int ClienteID { get; set; }
        public virtual PacienteViewModel Paciente { get; set; }
        public int ProcedimentoEmpresaID { get; set; }
    }

}
