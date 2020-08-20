using database.portal.jenn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{

    
    public class NovaConfirmacaoAgendaViewModel
    {

        public string CarteirinhaConvenio { get; set; }
        public bool contraste { get; set; }
        public bool PacienteTitular { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }
        public string AlergiaReacoes { get; set; }
        public int PlanoID { get; set; }
        public int AgendaID { get; set; }
        public int ProcedimentoEmpresaID { get; set; }
      
        
        public virtual ClienteViewModel Cliente { get; set; }
        public virtual PacienteViewModel Paciente { get; set; }

    }

    public class ConsultaNovaConfirmacaoAgendaViewModel
    {

        public string CarteirinhaConvenio { get; set; }
        public bool contraste { get; set; }
        public bool PacienteTitular { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }
        public string AlergiaReacoes { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
        public virtual PacienteViewModel Paciente { get; set; }
        public virtual ConsultaPlanoViewModel Plano { get; set; }
        public virtual ConsultaAgendaViewModel Agenda { get; set; }
        public virtual ConsultaProcedimentoEmpresaViewModel ProcedimentoEmpresa { get; set; }
    }
}
