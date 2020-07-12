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
    }
}
