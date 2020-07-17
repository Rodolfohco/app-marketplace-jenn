using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{

    [Table("cliente")]
    public class Cliente
    {

        [Key]
        [Column("cod_cliente", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClienteID { get; set; }

        [Required]
        [Column("nom_cliente", Order = 2)]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column("sobnom_cliente", Order = 3)]
        [StringLength(100)]
        public string sobrenome { get; set; }

        [Required]
        [Column("nasc_cliente", Order = 3)]
        [DataType(DataType.Date)]
        public DateTime DtaNascimento { get; set; }

        [Required]
        [Column("cpf_cliente", Order = 3)]
        [StringLength(11)]
        public string cpf_cliente { get; set; }

        [Required]
        [Column("sex_cliente", Order = 3)]
        [StringLength(1)]
        public string Sexo { get; set; }

        [Required]
        [Column("tel_cliente", Order = 3)]
        [StringLength(20)]
        public string Telefone { get; set; }

        [Column("cel_cliente", Order = 3)]
        [StringLength(21)]
        public string Celular { get; set; }

        [Column("logr_cliente", Order = 3)]
        [StringLength(150)]
        public string Logradouro { get; set; }

        [Column("num_cliente", Order = 3)]
        [StringLength(12)]
        public string numero { get; set; }

        [Column("bai_cliente", Order = 3)]
        [StringLength(100)]
        public string bairro { get; set; }


        [Column("cep_cliente", Order = 3)]
        [StringLength(20)]
        public string Cep { get; set; }


        [Column("refer_cliente", Order = 3)]
        [StringLength(200)]
        public string Referencia { get; set; }

        
        
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Avalia> Avaliacao { get; set; }
    }
}
