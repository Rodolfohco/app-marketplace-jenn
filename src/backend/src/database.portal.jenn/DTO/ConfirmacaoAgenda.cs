﻿using database.portal.jenn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{

    [Table("proceagendaconfirma")]
    public class ConfirmacaoAgenda
    {
        [Key]
        [Column("cod_confirma_agenda", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConfirmacaoAgendaID { get; set; }

        [Required]
        [StringLength(200)]
        [Column("num_carteirinha_convenio", Order = 1)]
        public string CarteirinhaConvenio { get; set; }

        [Required]
        [Column("bln_contr", Order = 2, TypeName = "bit")]
        public bool contraste { get; set; }

        [Required]
        [Column("bln_paciente_tiular", Order = 3, TypeName = "bit")]
        public bool PacienteTitular { get; set; }

        [Required]
        [Column("peso_paciente", Order = 4, TypeName = "float")]
        public float Peso { get; set; }

        [Required]
        [Column("altura_pac", Order = 5, TypeName = "float")]
        public float Altura { get; set; }

        [Required]
        [Column("alergia_reacoes", Order = 6)]
        public string AlergiaReacoes { get; set; }
        public virtual Plano Plano { get; set; }
        public virtual Agenda Agenda { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Paciente Paciente { get; set; }    
        public virtual ProcedimentoEmpresa ProcedimentoEmpresa { get; set; }
    }
}
