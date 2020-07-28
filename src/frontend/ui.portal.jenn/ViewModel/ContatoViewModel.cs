using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewModel
{
    public class ContatoViewModel
    {

        [Required]
        [StringLength(200)]
        [Display(Name = "Nome :")]
        public string Nome { get; set; }


        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }


        [Required]
        [StringLength(800)]
        [Display(Name = "Mensagem")]
        [DataType(DataType.MultilineText)]
        public string mensagem_cont { get; set; }
    }
}
