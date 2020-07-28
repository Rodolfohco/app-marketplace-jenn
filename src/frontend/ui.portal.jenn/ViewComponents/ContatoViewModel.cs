using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewComponents
{
    public class ContatoViewModel
    {

        [Required(ErrorMessage = "O Campo é obrigatório", AllowEmptyStrings = false)] 
        public string Nome { get; set; }


        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")] 
        public string Email { get; set; }

        public string Telefone { get; set; }


        [Required(ErrorMessage = "O Campo Mensagem é obrigatório", AllowEmptyStrings = false)]
        public string Mensagem { get; set; }
    }
}
