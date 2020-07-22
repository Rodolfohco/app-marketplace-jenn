using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{

    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("cod_usuario", Order = 1)]
        public int UsuarioID { get; set; }


        [Required]
        [Column("mail_usuario", Order = 3)]
        [StringLength(100)]
        public string Email { get; set; }


        [Required]
        [StringLength(100)]
        public string Nome { get; set; }




        public int? ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual Logon logon { get; set; }
    }
}
