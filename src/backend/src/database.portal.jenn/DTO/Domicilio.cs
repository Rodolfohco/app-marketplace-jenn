using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    [Table("domic")]
    public class Domicilio
    {
        [Key]
        [Column("cod_domic", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DomicilioID { get; set; }

       
        [Column("precodom_domic", Order = 2)]
        [StringLength(4)]
        public float PrecoDomicilio { get; set; }

        public virtual Cidade Cidade { get; set; }
        public virtual ProcedimentoEmpresa ProcedimentoEmpresa { get; set; }

    }
}
