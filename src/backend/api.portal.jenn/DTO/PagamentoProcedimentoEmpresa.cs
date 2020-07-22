using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    [Table("pgtoprocemp")]
    public class PagamentoProcedimentoEmpresa
    {
        [Key]
        [Column("cod_pgtoprocemp", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PagamentoProcedimentoEmpresaID { get; set; }

        public int PlanoID { get; set; }
        public virtual Pagamento Pagamento { get; set; }

        

        public virtual ProcedimentoEmpresa ProcedimentoEmpresa { get; set; }
    }
}
