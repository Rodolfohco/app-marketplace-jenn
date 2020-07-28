using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewModel
{
    public class PesquisaViewModel
    {

        [StringLength(300,ErrorMessage ="Quantidade minima de caracteres 3 ", MinimumLength =3)]
        [Required(ErrorMessage ="Campo requerido")]
        public string Produto { get; set; }
        public string Localidade { get; set; }
        public string NomeEmpresa { get; set; }
        public string DescricaoProcedimento { get; set; }
        public string NomeUnidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public string EnderecoLoja { get; set; }
        public int Opiniao { get; set; }
        public string UrlImagem { get; set; }
        public string UrlMaps { get; set; }

        public List<TipoProcedimentoViewModel> tipoProcedimentoViewModels { get; set; }

        public List<Convenio> Convenios { get; set; }

    }
}
