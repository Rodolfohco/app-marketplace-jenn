using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    [Table("grupo")]
    public class Grupo
    {
        [Key]
        [Column("cod_grupo", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GrupoID { get; set; }

        [Required]
        [Column("nom_grupo", Order = 1)]
        [StringLength(100)]
        public string Nome { get; set; }
           }
}
