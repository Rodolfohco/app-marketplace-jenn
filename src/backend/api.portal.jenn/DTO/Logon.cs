using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.portal.jenn.DTO
{



    [Table("Logon")]
    public class Logon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogonID { get; set; }


        [Required]
        [Column("usua_logon", Order = 2)]
        [StringLength(100)]
        public string Usuario { get; set; }
        [Required]
        [Column("password", Order = 2)]
        [StringLength(100)]
        public string Senha { get; set; }
   
        public virtual ICollection<Roles> Papeis { get; set; }
    }

    


    [Table("papeis")]
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }

        [Required]
        [Column("papel", Order = 2)]
        [StringLength(100)]
        public string Role { get; set; }
    }
}