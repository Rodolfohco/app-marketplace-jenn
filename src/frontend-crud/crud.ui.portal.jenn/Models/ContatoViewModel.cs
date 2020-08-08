using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn.Models
{
    public class ContatoViewModel
    {
        [Display(Name = "Contato")]
        public int ContatoId { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }


        [Display(Name = "Mensagem")]
        [DataType(DataType.MultilineText)]
        public string mensagem_cont { get; set; }
    }

        public class NovoContatoViewModel
    {

     
        [Required]
        [StringLength(200)]
        [Display(Name = "Nome")]
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
        [Display(Name ="Mensagem")]
        [DataType(DataType.MultilineText)]
        public string mensagem_cont { get; set; }
    }
}
