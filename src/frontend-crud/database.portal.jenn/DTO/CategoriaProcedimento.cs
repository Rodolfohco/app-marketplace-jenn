﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{
    [Table("procedcat")]
    public class CategoriaProcedimento
    {
        [Key]
        [Column("cod_categoria", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaID { get; set; }
        
        [Required]
        [Column("nom_categoria", Order = 1)]
        [StringLength(200)]
        public string Nome { get; set; }

        public virtual ICollection<TipoProcedimento> TiposProcedimentos { get; set; }
    }
}
