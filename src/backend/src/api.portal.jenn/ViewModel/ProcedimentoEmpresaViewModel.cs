using api.portal.jenn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
        public class NovoProcedimentoEmpresaViewModel
    {

        public DateTime DataInclusao { get; set; }
        public string Nome_pers { get; set; }

        public float PrecoProduto { get; set; }

        public float Preco_contra { get; set; }

        public string TaxaParcelamento { get; set; }

        public string TaxaResultado { get; set; }

        public string ImagemThumb { get; set; }


        public string ImagemHome { get; set; }

        public string ImagemMain { get; set; }

        public string Video { get; set; }
        public int Ativo { get; set; }

        public int ProcedimentoID { get; set; }
        public int EmpresaID { get; set; }
        public int? Destaque { get; set; }
    }
    public class ProcedimentoEmpresaViewModel
    {
        public int ProcedimentoEmpresaID { get; set; }

        public DateTime DataInclusao { get; set; }
        public string Nome_pers { get; set; }

        public float PrecoProduto { get; set; }

        public float Preco_contra { get; set; }

        public string TaxaParcelamento { get; set; }

        public string TaxaResultado { get; set; }

        public string ImagemThumb { get; set; }


        public string ImagemHome { get; set; }

        public string ImagemMain { get; set; }

        public string Video { get; set; }
        public int Ativo { get; set; }

        public int? Destaque { get; set; }
        public virtual ProcedimentoViewModel Procedimento { get; set; }

        public virtual EmpresaViewModel Empresa { get; set; }
        public virtual ICollection<PlanoProcedimentoEmpresaViewModel> PlanoProcedimentoEmpresas { get; set; }
        public virtual ICollection<ProcedimentoPerguntaViewModel> ProcedimentoPerguntas { get; set; }
        public virtual ICollection<PagamentoProcedimentoEmpresaViewModel> PagamentoProcedimentoEmpresas { get; set; }

    }

    public class ConsultaProcedimentoEmpresa2ViewModel
    {
        public int ProcedimentoEmpresaID { get; set; }

        public DateTime DataInclusao { get; set; }
        public string Nome_pers { get; set; }

        public float PrecoProduto { get; set; }

        public float Preco_contra { get; set; }

        public string TaxaParcelamento { get; set; }

        public string TaxaResultado { get; set; }

        public string ImagemThumb { get; set; }


        public string ImagemHome { get; set; }

        public string ImagemMain { get; set; }

        public string Video { get; set; }
        public int Ativo { get; set; }

        public int? Destaque { get; set; }

        public virtual EmpresaViewModel Empresa { get; set; }
        public virtual ProcedimentoViewModel Procedimento { get; set; }

        public virtual ICollection<ConsultaAgendaViewModel> Agendas { get; set; }

        public virtual ICollection<PlanoProcedimentoEmpresaViewModel> PlanoProcedimentoEmpresas { get; set; }
        public virtual ICollection<ProcedimentoPerguntaViewModel> ProcedimentoPerguntas { get; set; }
        public virtual ICollection<ConsultaPagamentoProcedimentoEmpresaViewModel> PagamentoProcedimentoEmpresas { get; set; }

    }
    public class ConsultaProcedimentoEmpresaViewModel
    {
        public int ProcedimentoEmpresaID { get; set; }

        public DateTime DataInclusao { get; set; }
        public string Nome_pers { get; set; }

        public float PrecoProduto { get; set; }

        public float Preco_contra { get; set; }

        public string TaxaParcelamento { get; set; }

        public string TaxaResultado { get; set; }

        public string ImagemThumb { get; set; }


        public string ImagemHome { get; set; }

        public string ImagemMain { get; set; }

        public string Video { get; set; }
        public int Ativo { get; set; }

        public int? Destaque { get; set; }
        public virtual ProcedimentoViewModel Procedimento { get; set; }

        public virtual ICollection<ConsultaAgendaViewModel> Agendas { get; set; }
        
        public virtual ICollection<PlanoProcedimentoEmpresaViewModel> PlanoProcedimentoEmpresas { get; set; }
        public virtual ICollection<ProcedimentoPerguntaViewModel> ProcedimentoPerguntas { get; set; }
        public virtual ICollection<ConsultaPagamentoProcedimentoEmpresaViewModel> PagamentoProcedimentoEmpresas { get; set; }

    }
}
