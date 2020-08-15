using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.DTO
{


    [Table("proceagenda")]
    public class Agenda
    {
        [Key]
        [Column("cod_agenda", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgendaID { get; set; }

        [Column("agen_mes", Order = 1)]
        public int Mes { get; set; }

        [Column("agen_dia", Order = 1)]
        public int Dia { get; set; }

        [Column("agen_hora", Order = 1)]
        public DateTime Hora { get; set; }

        [Column("agen_datvige", Order = 1)]
        public DateTime DataVigencia { get; set; }

        [Column("agen_atv", Order = 1)]
        public bool Ativo { get; set; }

        public virtual ProcedimentoEmpresa ProcedimentoEmpresa { get; set; }
    }
}
