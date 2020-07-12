using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
    public class UnidadeViewModel
    {
        public Guid UnidadeID { get; set; }
        public Guid EmpresaID { get; set; }
        public Guid CidadeID { get; set; }
        public string Nome { get; set; }
    }
}
