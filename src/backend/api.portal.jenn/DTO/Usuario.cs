using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{

    [Table("UsuarioTB")]
    public class Usuario
    {
            [Key]
            [Column("UsuarioID", Order = 1)]
            public Guid UsuarioID { get; set; }

            [Required]
            [Column("Nome", Order = 3)]
            [StringLength(200)]
            public string Nome { get; set; }

           
            public virtual Logon logon { get; set; }
        }
}
