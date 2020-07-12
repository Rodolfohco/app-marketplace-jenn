using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
    public class ProdutoViewModel
    {
        public Guid ProdutoID { get; set; }

        public string Nome { get; set; }

        public Guid? Cidade { get; set; }

        public Guid? Unidade { get; set; }

        public Guid? PlanoUnidade { get; set; }
    }
}
