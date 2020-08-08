using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn.Models
{
    public class ProdutoViewModel
    {
        public int ProdutoID { get; set; }

        public string Nome { get; set; }

        public int? Cidade { get; set; }

        public int? Unidade { get; set; }

        public int? PlanoUnidade { get; set; }
    }
}
