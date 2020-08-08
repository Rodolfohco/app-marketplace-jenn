using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    [Table("contato")]
    public class Contato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cod_cont", Order = 0)]
        public int ContatoID { get; set; }

        [Required]
        [Column("nom_cont", Order = 1)]
        [StringLength(200)]
        public string Nome { get; set; }
        
        
        [Column("tele_cont", Order = 1)]
        [StringLength(200)]
        public string Telefone { get; set; }

        [Required]
        [Column("email_cont", Order = 1)]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [Column("mensagem_cont", Order = 1)]
        [StringLength(800)]
        public string mensagem_cont { get; set; }

    }
}
