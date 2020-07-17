using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{


    public class TipoProcedimentoViewModel
    {
        public Guid TipoProcedimentoID { get; set; }
        public string Nome { get; set; }
        public virtual CategoriaProcedimentoViewModel Categoria { get; set; }
    }
}
