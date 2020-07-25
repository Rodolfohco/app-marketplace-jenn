using api.portal.jenn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
    public class ProcedimentoEmpresaViewModel
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
        public EmpresaViewModel Empresa { get; set; }
        public ProcedimentoViewModel Procedimento { get; set; }


        public ICollection<ProcedimentoPerguntaViewModel> ProcedimentoPerguntas { get; set; }

        public ICollection<PagamentoProcedimentoEmpresaViewModel> PagamentoProcedimentoEmpresas { get; set; }
        //public ICollection<PlanoProcedimentoEmpresaViewModel> PlanoProcedimentoEmpresas { get; set; }
    }


}
