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
        [Column("cod_uf", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UfID { get; set; }

        [Required]
        [Column("nom_uf", Order = 3)]
        [StringLength(200)]
        public string Nome { get; set; }
        public virtual Cidade cidade { get; set; }

        public virtual Pais Pais { get; set; }

    }
}
