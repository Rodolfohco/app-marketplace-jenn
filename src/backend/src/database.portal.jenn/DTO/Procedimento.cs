using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
   [Table("proced")]
    public class Procedimento
    {
        [Key]
        [Column("cod_proced", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProcedimentoID { get; set; }

        [Required]
        [Column("nom_proced", Order = 1)]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [Column("desc_proced", Order = 2)]
        [StringLength(400)]
        public string Descricao { get; set; }

 
        [Column("imgprod_proced", Order = 3)]
        [StringLength(200)]
        public string ImgProduto_Proc { get; set; }

 
        [Column("atv_proced", Order = 1)]
        public Status Ativo { get; set; }

        public virtual TipoProcedimento TipoProcedimento { get; set; }

        public virtual ICollection<ProcedimentoSinonimo> ProcedimentoSinonimos { get; set; }
        public virtual ICollection<ProcedimentoEmpresa> ProcedimentoEmpresas{ get; set; }

    }
}
