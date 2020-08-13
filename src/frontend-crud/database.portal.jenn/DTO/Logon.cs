using System;
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
        [Column("usua_nome", Order = 2)]
        [StringLength(200)]
        [DataType(DataType.Text)]
        public string Nome { get; set; }


        [Required]
        [Column("usua_email", Order = 2)]
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Column("password", Order = 2)]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [Column("dt_inclusao")]
        public DateTime DataInclusao { get; set; }
        
        [Column("atv_logon", Order = 16)]
        [StringLength(1)]
        public int Ativo { get; set; }

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