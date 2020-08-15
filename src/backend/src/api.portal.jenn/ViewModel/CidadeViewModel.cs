using api.portal.jenn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
    public class CidadeViewModel
    {
        
        public int CidadeID { get; set; }
        public string Nome { get; set; }
        public string num_cidade { get; set; }
        public virtual ICollection<RegiaoViewModel> Regiao { get; set; }
        public virtual UFViewModel Uf { get; set; }
    }

    public class NovaCidadeViewModel
    {

        public string Nome { get; set; }
        public string num_cidade { get; set; }

        public virtual ICollection<RegiaoViewModel> Regiao { get; set; }
        public virtual ICollection<UFViewModel> Ufs { get; set; }
    }
}
