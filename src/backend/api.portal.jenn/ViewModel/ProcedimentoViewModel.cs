using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{

    public class ProcedimentoViewModel
    {

        public Guid ProcedimentiID { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [StringLength(400)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(200)]
        public string ImgProduto_Proc { get; set; }


        [Required]
        [StringLength(1)]
        public int Ativo { get; set; }

    }
}
