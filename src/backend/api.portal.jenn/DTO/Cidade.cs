using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{

    [Table("CidadeTB")]
    public class Cidade
    {

        [Key]
        [Column("CidadeID", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CidadeID { get; set; }

        [Required]
        [Column("Nome", Order = 3)]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [Column("UF", Order = 3)]
        [StringLength(2)]
        public string UF { get; set; }
        public virtual Unidade Unidade { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}
