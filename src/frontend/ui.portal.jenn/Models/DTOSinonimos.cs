using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.Models
{

        public class DTOSinonimos
        {
            public object token { get; set; }
            public bool success { get; set; }
            public string message { get; set; }
            public Sinonimo[] data { get; set; }
        }

        public class Sinonimo
    {
            public int procedimentoSinonimoID { get; set; }
            public string nome { get; set; }
            public int ativo { get; set; }
            public ProcedimentoSinonimo procedimento { get; set; }
        }

        public class ProcedimentoSinonimo
    {
            public int procedimentoID { get; set; }
            public string nome { get; set; }
            public string descricao { get; set; }
            public string imgProduto_Proc { get; set; }
            public int ativo { get; set; }
            public TipoprocedimentoSinonimo tipoProcedimento { get; set; }
        }

        public class TipoprocedimentoSinonimo
    {
            public int tipoProcedimentoID { get; set; }
            public string nome { get; set; }
            public CategoriaSinonimo categoria { get; set; }
        }

        public class CategoriaSinonimo
        {
            public int categoriaID { get; set; }
            public string nome { get; set; }
        }

    
}
