using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{


    [Table("EmpresaTB")]
    public class Empresa
    {
        [Key]
        [Column("EmpresaID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EmpresaID { get; set; }
 
        [Required]
        [Column("Nome", Order = 1)]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [Column("DataInclusao", Order = 4)]
        public DateTime DataInclusao { get; set; }


        [Column("Status", Order = 1)]
        public int Ativo { get; set; }
        public virtual ICollection<Unidade> Unidade { get; set; }

    }
}
