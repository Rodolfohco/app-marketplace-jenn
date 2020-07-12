using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewModel
{
    public class EmpresaViewModel
    {
        public Guid EmpresaID { get; set; }

        public string Nome { get; set; }

        public DateTime DataInclusao { get; set; }

        public int Ativo { get; set; }
    }
}
