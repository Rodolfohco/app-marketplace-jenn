using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    [Table("PlanoUnidadeProdutoTB")]
    public class PlanoUnidadeProduto
    {
        [Key]
        public Guid PlanoUnidadeProdutoID { get; set; }



        public Guid UnidadeProdutoID { get; set; }
        public virtual UnidadeProduto UnidadeProduto { get; set; }


        //public Guid ProdutoID { get; set; }
        //public virtual Produto Produto { get; set; }


        //[ForeignKey("ConvenioPlanoID")]
        //public int? ConvenioPlanoID { get; set; }



    }


}
