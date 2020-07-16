using Microsoft.AspNetCore.Routing.Constraints;
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
        [Column("cod_procemp", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProcedimentoEmpresaID { get; set; }

        [Column("com_emp", Order = 1)]
        public Guid EmpresaID { get; set; }

        [Column("cod_proced", Order = 2)]
        public Guid ProcedimentiID { get; set; }


        [Column("dataincl_procemp", Order = 3)]
        public DateTime DataInclusao { get; set; }

        [Required]
        [Column("nompers_procemp", Order = 4)]
        [StringLength(100)]
        public string Nome_pers { get; set; }

        [Required]
        [Column("precoprod_procemp", Order = 5)]
        public float PrecoProduto { get; set; }

        [Required]
        [Column("precocontra_procemp", Order = 6)]
        public float Preco_contra { get; set; }

        [Column("descprod_procemp", Order = 7)]
        public byte[] descprod_procemp { get; set; }

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

        [Required]
        [Column("atv_proced", Order = 14)]
        [StringLength(1)]
        public int Ativo { get; set; }

        public virtual ICollection<Procedimento> Procedimentos { get; set; }
        public virtual ICollection<ProcedimentoPergunta> ProcedimentoPerguntas { get; set; }
        public virtual ICollection<PagamentoProcedimentoEmpresa> PagamentoProcedimentoEmpresas { get; set; }
        public virtual PlanoProcedimentoEmpresa PlanoProcedimentoEmpresas { get; set; }
        public virtual Empresa Empresa { get; set; }

    }
}
