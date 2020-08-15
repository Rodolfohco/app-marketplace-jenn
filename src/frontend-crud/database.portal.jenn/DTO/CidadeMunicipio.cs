using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace database.portal.jenn.DTO
{
    public class CidadeMunicipio
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CidadeID { get; set; }
        public string CodIbge { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

    }
}
