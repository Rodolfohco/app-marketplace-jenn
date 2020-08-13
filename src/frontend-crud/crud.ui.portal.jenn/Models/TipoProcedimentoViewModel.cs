using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn.Models
{


    public class TipoProcedimentoViewModel
    {
        public int TipoProcedimentoID { get; set; }
        public string Nome { get; set; }
        public virtual CategoriaProcedimentoViewModel Categoria { get; set; }
    }
}
