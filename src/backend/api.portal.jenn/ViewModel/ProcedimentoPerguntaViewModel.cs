using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
    public class ProcedimentoPerguntaViewModel
    {
        public Guid ProcedimentoPerguntaID { get; set; }

        public string titulo { get; set; }

        public string descricao { get; set; }

        public int Ativo { get; set; }
    }
}
