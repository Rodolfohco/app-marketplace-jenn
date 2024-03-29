﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
  [Table("plano_conv")]
    public class Plano
    {
        [Key]
        [Column("cod_plano", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlanoID { get; set; }

        [Required]
        [Column("nom_plano", Order = 2)]
        [StringLength(200)]
        public string Nome { get; set; }


        [Column("atv_plano", Order = 2)]
        public Status Ativo { get; set; }
        public virtual ICollection<PlanoProcedimentoEmpresa> PlanoProcedimentoEmpresas { get; set; }

        public virtual Convenio Convenio { get; set; }
    }
}