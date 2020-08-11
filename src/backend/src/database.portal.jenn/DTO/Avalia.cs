using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
 
  [Table("avalia")]
    public class Avalia
    {
        [Key]
        [Column("cod_avalia", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvaliaID { get; set; }

        [Required]
        [Column("nps_avalia", Order = 2)]
        [StringLength(4)]
        public string Avaliacao { get; set; }

        [Required]
        [Column("obs_avalia", Order = 3)]
        [StringLength(400)]
        public string Observacao { get; set; }


        [Required]
        [Column("feedback_avalia", Order = 4)]
        [StringLength(2)]
        public string feedback { get; set; }


        public virtual Empresa Empresa { get; set; }
        public virtual Cliente Cliente { get; set; }


    
    }
}
