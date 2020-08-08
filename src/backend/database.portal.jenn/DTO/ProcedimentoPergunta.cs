using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{



 [Table("procperg")]
    public class ProcedimentoPergunta
    {
        [Key]
        [Column("cod_procperg", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProcedimentoPerguntaID { get; set; }

        [Required]
        [Column("titulo_procperg", Order = 1)]
        [StringLength(150)]
        public string titulo { get; set; }

        [Required]
        [Column("desc_procperg", Order = 2)]
        [StringLength(300)]
        public string descricao { get; set; }

        [Required]
        [Column("atv_proced", Order = 3)]
        [StringLength(1)]
        public int Ativo { get; set; }



        public virtual ProcedimentoEmpresa ProcedimentoEmpresa { get; set; }

    }
}
