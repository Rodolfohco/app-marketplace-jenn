﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{


    [Table("pais")]
    public class Pais
    {
        [Key]
        [Column("cod_pais", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PaisID { get; set; }

        [Required]
        [Column("nom_pais", Order = 3)]
        [StringLength(200)]
        public string Nome { get; set; }

        public virtual ICollection<UF> Ufs { get; set; }
    }
}
