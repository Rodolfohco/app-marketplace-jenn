using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    [Table("UnidadeTB")]
    public class Unidade
    {
        [Key]
        [Column("UnidadeID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UnidadeID { get; set; }
        

        [Required]
        [Column("Nome", Order =3 )]
        [StringLength(200)]
        public string Nome { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<UnidadeProduto> UnidadeProdutos { get; set; }

    }
}
