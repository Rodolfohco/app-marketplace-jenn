using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{   
   [Table("conv")]
    public class Convenio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cod_conv", Order = 0)]
        public int ConvenioId { get; set; }

        [Required]
        [Column("nom_conv", Order = 1)]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [Column("data_inc", Order = 2)]
        public DateTime DataInclusao { get; set; }

        
        [Column("atv_conv", Order =3)]
        public Status Ativo { get; set; }
        public virtual ICollection<Plano> Planos { get; set; }
    }
}
