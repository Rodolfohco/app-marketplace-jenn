using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    [Table("tipo_proced")]
    public class TipoProcedimento
    {
        [Key]
        [Column("cod_tipproced", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TipoProcedimentoID { get; set; }

        [Required]
        [Column("nom_tipproced", Order = 1)]
        [StringLength(200)]
        public string Nome { get; set; }

        public virtual Procedimento Procedimento { get; set; }
        public Guid ProcedimentoID { get; set; }

        public Guid CategoriaID { get; set; }
        public virtual CategoriaProcedimento Categoria { get; set; }
    }
}
