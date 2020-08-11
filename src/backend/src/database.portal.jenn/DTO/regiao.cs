using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    [Table("regiao")]
    public class Regiao
    {
        [Key]
        [Column("cod_regiao", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UfID { get; set; }

        [Required]
        [Column("nom_reg", Order = 3)]
        [StringLength(200)]
        public string Nome { get; set; }

    }
}
