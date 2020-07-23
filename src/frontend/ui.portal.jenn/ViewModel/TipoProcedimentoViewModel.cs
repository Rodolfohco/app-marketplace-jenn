using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewModel
{
    public class TipoProcedimentoViewModel
    {

        public int TipoProcedimentoID { get; set; }
        public string Nome { get; set; }
        public virtual CategoriaProcedimentoViewModel Categoria { get; set; }
    }
}
