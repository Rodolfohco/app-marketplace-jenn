using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{

    [Table("ProdutoTB")]
    public class Produto
    {
        [Key]
        [Column("ProdutoID", Order = 0)]
        public Guid ProdutoID { get; set; }


        [Required]
        [Column("Nome", Order = 2)]
        [StringLength(200)]
        public string Nome { get; set; }



        public virtual Cidade Cidade { get; set; }
        public virtual Unidade Unidade { get; set; }
        public virtual PlanoUnidadeProduto PlanoUnidadeProduto { get; set; }

        public virtual ICollection<UnidadeProduto> UnidadeProdutos { get; set; }

    }
}
