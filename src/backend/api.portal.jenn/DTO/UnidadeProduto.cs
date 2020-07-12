using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{

    [Table("UnidadeProdutoTB")]
    public class UnidadeProduto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UnidadeProdutoID", Order = 0)]
        public Guid UnidadeProdutoID { get; set; }

        [Column("Preco_Produto", Order = 3)]
        public double Preco_Produto { get; set; }

        [Column("Preco_Domicilio", Order = 3)]
        public double Preco_Domicilio { get; set; }

        public virtual Unidade Unidade { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual PlanoUnidadeProduto  PlanoUnidadeProdutos { get; set; }
    }
}
