using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{

    [Table("planoprocemp")]
    public class PlanoProcedimentoEmpresa
    {
        [Key]
        [Column("cod_planoprocemp", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlanoProcedimentoEmpresaID { get; set; }



        //public int ProcedimentoEmpresaID { get; set; }
        //public virtual ProcedimentoEmpresa ProcedimentoEmpresa { get; set; }

        public int PlanoID { get; set; }
        public virtual Plano Plano { get; set; }
    }
}
