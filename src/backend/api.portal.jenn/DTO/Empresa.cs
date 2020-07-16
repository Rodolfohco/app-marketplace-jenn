using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{


    [Table("emp")]
    public class Empresa
    {
        [Key]
        [Column("cod_emp", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EmpresaID { get; set; }

        [Required]
        [Column("cnpj_emp", Order = 1)]
        [StringLength(14)]
        public string cnpj { get; set; }

        [Required]
        [Column("nome_emp", Order = 2)]
        [StringLength(200)]
        public string Nome { get; set; }

        [Column("cod_matriz_emp", Order = 3)]
        public Guid MatrizID { get; set; }

        [Required]
        [Column("tel_emp1", Order = 4)]
        [StringLength(20)]
        public string Telefone1 { get; set; }

        [Column("tel_emp2", Order = 5)]
        [StringLength(20)]
        public string Telefone2 { get; set; }

        [Column("imgfront_emp", Order = 6)]
        [StringLength(100)]
        public string ImgemFrontEmpresa { get; set; }

        [Column("mail_emp", Order = 7)]
        [StringLength(100)]
        public string Email { get; set; }

        [Column("logr_emp", Order = 8)]
        [StringLength(150)]
        public string Logradouro { get; set; }

        [Column("num_emp", Order = 9)]
        [StringLength(12)]
        public string numero { get; set; }

        [Column("bai_emp", Order = 10)]
        [StringLength(100)]
        public string bairro { get; set; }

        [Column("cep_emp", Order = 11)]
        [StringLength(16)]
        public string cep { get; set; }

        [Column("maps_emp", Order = 12)]
        [StringLength(200)]
        public string maps { get; set; }


        [Column("reps_emp", Order = 13)]
        [StringLength(200)]
        public string Responsavel { get; set; }


        [Column("id_classe", Order = 14)]
        [StringLength(10)]
        public string Id_classe { get; set; }


        [Column("cert_emp", Order = 15)]
        [StringLength(2)]
        public string Cert_Empresa { get; set; }

        [Column("atv_proced", Order = 16)]
        [StringLength(1)]
        public int Ativo { get; set; }

        public Guid GrupoID { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
        public virtual ICollection<FotoEmpresa> Fotos { get; set; }
        public virtual ICollection<Avalia> Avaliacoes { get; set; }
    }
   
}
