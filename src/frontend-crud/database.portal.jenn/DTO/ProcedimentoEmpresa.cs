
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    [Table("procemp")]
    public class ProcedimentoEmpresa
    {
        [Key]
        [Column("cod_procemp", Order = 16)]
        public int ProcedimentoEmpresaID { get; set; }

       
        [Column("dataincl_procemp", Order = 1)]
        public DateTime DataInclusao { get; set; }

        [Required]
        [Column("nompers_procemp", Order = 2)]
        [StringLength(100)]
        public string Nome_pers { get; set; }

        [Required]
        [Column("precoprod_procemp", Order = 3)]
        public float PrecoProduto { get; set; }

        [Required]
        [Column("precocontra_procemp", Order = 6)]
        public float Preco_contra { get; set; }

        [Required]
        [Column("txtparcel_procemp", Order = 8)]
        [StringLength(200)]
        public string TaxaParcelamento { get; set; }

        [Required]
        [Column("txtresult_procemp", Order = 9)]
        [StringLength(200)]
        public string TaxaResultado { get; set; }

        [Required]
        [Column("imgthumb_procemp", Order = 10)]
        [StringLength(100)]
        public string ImagemThumb { get; set; }


        [Required]
        [Column("imghome_procemp", Order = 11)]
        [StringLength(100)]
        public string ImagemHome { get; set; }

        [Required]
        [Column("imgmain_procemp", Order = 12)]
        [StringLength(100)]
        public string ImagemMain { get; set; }

        [Required]
        [Column("video_procemp", Order = 13)]
        [StringLength(100)]
        public string Video { get; set; }

        [Column("atv_proced", Order = 14)]        
        public int Ativo { get; set; }

        [Column("dest_proced")]
        public int? Destaque { get; set; }


        [ForeignKey("cod_proced")]
        [Column("cod_proced", Order = 15)]
        public int ProcedimentoID { get; set; }
        public virtual Procedimento Procedimento { get; set; }


        [ForeignKey("cod_emp")]
        [Column("cod_emp", Order = 16)]
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
          public virtual ICollection<PlanoProcedimentoEmpresa> PlanoProcedimentoEmpresas { get; set; }
        public virtual ICollection<ProcedimentoPergunta> ProcedimentoPerguntas { get; set; }
        public virtual ICollection<PagamentoProcedimentoEmpresa> PagamentoProcedimentoEmpresas { get; set; }

    }
}
