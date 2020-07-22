using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    [Table("fotoemp")]
    public class FotoEmpresa
    {
        [Key]
        [Column("cod_foto", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FotoID { get; set; }

        [Required]
        [Column("path_emp", Order = 1)]
        [StringLength(100)]
        public string path { get; set; }

        [Required]
        [Column("nome_foto", Order = 1)]
        [StringLength(100)]
        public string Nome { get; set; }


        public virtual Empresa Empresa { get; set; }
        
    }
}
