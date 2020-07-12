using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewModel
{
    public class LoginViewModel
    {

        [Display(Name = "Informe o E-mail Para acessar")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Formato do E-mail invalido")]
        [Required(ErrorMessage ="Campo E-mail Obrigatorio")]
        public string Email { get; set; }


        [Display(Name ="Informe a seua Senha")]
        [DataType(DataType.Password, ErrorMessage = "Formato do Senha invalido")]
        [Required(ErrorMessage = "Campo Senha Obrigatorio")]
        public string Senha { get; set; }
    }
}
