using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn.Models
{
    public class NovoLogonViewModel
    {
        [Required(ErrorMessage ="O Campo Nome é Obrigatorio")]
        [StringLength(200, MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O Campo E-mail é Obrigatorio")]
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail: ")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100)]
        [Display(Name = "Senha: ")]
        public string Password { get; set; }


        [DataType(DataType.Date)]
        public DateTime DataInclusao { get; set; }
         
        public int Ativo { get; set; }

        
        public  ICollection<RolesViewModel> Papeis { get; set; }
    }


    public class ConsultaLogonViewModel
    {
        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "O Campo Nome é obrigatorio")]
        public string Nome { get; set; }

        [Display(Name = "E-Mail:")]
        [Required(ErrorMessage = "O Campo E-Mail é obrigatorio")]
        public string Email { get; set; }

        //[Display(Name = "Senha:")]
        //[Required(ErrorMessage = "O Campo Password é obrigatorio")]
        //public string Password { get; set; }
        public DateTime DataInclusao { get; set; }
        public int Ativo { get; set; }
        public ICollection<RolesViewModel> Papeis { get; set; }
    }

    public class AutenticarLogonViewModel
    {
        [Display(Name = "E-Mail:")]
        [Required(ErrorMessage = "O Campo E-Mail é obrigatorio")]
        public string Email { get; set; }

        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "O Campo Password é obrigatorio")]
        public string Password { get; set; }
    }

}
