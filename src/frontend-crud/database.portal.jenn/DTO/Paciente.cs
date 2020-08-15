using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace database.portal.jenn.DTO
{
    [Table("paciente")]
    public class Paciente
    {

        [Key]
        [Column("cod_paciente", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PacienteID { get; set; }

        [Required]
        [Column("nom_paciente", Order = 2)]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column("sobnom_paciente", Order = 3)]
        [StringLength(100)]
        public string sobrenome { get; set; }

        [Required]
        [Column("nasc_paciente", Order = 3)]
        [DataType(DataType.Date)]
        public DateTime DtaNascimento { get; set; }

        [Required]
        [Column("cpf_paciente", Order = 3)]
        [StringLength(11)]
        public string cpf_paciente { get; set; }

        [Required]
        [Column("sex_paciente", Order = 3)]
        [StringLength(1)]
        public string Sexo { get; set; }

        [Required]
        [Column("tel_paciente", Order = 3)]
        [StringLength(20)]
        public string Telefone { get; set; }

        [Column("cel_paciente", Order = 3)]
        [StringLength(21)]
        public string Celular { get; set; }

        [Column("logr_paciente", Order = 3)]
        [StringLength(150)]
        public string Logradouro { get; set; }

        [Column("num_paciente", Order = 3)]
        [StringLength(12)]
        public string numero { get; set; }

        [Column("bai_paciente", Order = 3)]
        [StringLength(100)]
        public string bairro { get; set; }


        [Column("cep_paciente", Order = 3)]
        [StringLength(20)]
        public string Cep { get; set; }


        [Column("refer_paciente", Order = 3)]
        [StringLength(200)]
        public string Referencia { get; set; }

 
    }
}
