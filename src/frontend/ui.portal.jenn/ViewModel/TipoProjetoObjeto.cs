using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewModel
{
    public class TipoProcedimentoObjeto
    {
        public string UrlBase { get; set; }

        public List<TipoProcedimentoViewModel> Tipoprocedimentos { get; set; }

        public TipoProcedimentoObjeto()
        {
            this.Tipoprocedimentos = new List<TipoProcedimentoViewModel>();
        }
    }
}
