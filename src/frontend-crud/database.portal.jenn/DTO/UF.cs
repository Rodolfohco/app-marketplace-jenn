using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    [Table("uf")]
    public class UF
    {
        [Key]
        [Column("cod_uf", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UfID { get; set; }

        [Required]
        [Column("num_uf", Order = 1)]
        [StringLength(3)]
        public string num_uf { get; set; }

        [Required]
        [Column("nom_uf", Order = 2)]
        [StringLength(200)]
        public string Nome { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
