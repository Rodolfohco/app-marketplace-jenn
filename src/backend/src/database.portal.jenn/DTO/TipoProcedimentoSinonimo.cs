using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
 


namespace api.portal.jenn.DTO
{
 
    [Table("proced_sinonimo")]
    public class ProcedimentoSinonimo
    {
        [Key]
        [Column("cod_tipproced", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProcedimentoSinonimoID { get; set; }

        [Required]
        [Column("nom_tipproced_sinonimo", Order = 1)]
        [StringLength(200)]
        public string Nome { get; set; }

        [Column("atv_tipo_proce_sinonimo", Order = 14)]
        public Status Ativo { get; set; }

        public virtual Procedimento Procedimento { get; set; }

    }
}