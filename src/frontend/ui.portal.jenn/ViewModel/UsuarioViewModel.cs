using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewModel
{
    public class UsuarioViewModel
    {
        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "O Campo Nome é obrigatorio")]
        public string Nome { get; set; }

        [Display(Name = "E-Mail:")]
        [Required(ErrorMessage = "O Campo E-Mail é obrigatorio")]
        public string Email { get; set; }

        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "O Campo Password é obrigatorio")]
        public string Password { get; set; }

    }
}
