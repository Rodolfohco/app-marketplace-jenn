
using crud.ui.portal.jenn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn.Models
{
    public class CidadeViewModel
    {
        
        public int CidadeID { get; set; }
        public string Nome { get; set; }
     
        public virtual ICollection<RegiaoViewModel> Regiao { get; set; }
        public virtual ICollection<UFViewModel> Ufs { get; set; }
    }

    public class NovaCidadeViewModel
    {

        public string Nome { get; set; }

        public virtual ICollection<RegiaoViewModel> Regiao { get; set; }
        public virtual ICollection<UFViewModel> Ufs { get; set; }
    }
}
