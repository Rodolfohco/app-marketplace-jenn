﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.ViewModel
{
    public class ConvenioViewModel
    { 
        public int ConvenioId { get; set; }        
        public string Nome { get; set; }
        public DateTime DataInclusao { get; set; }       
        public int Ativo { get; set; }
        public ICollection<PlanoViewModel> Planos { get; set; }
    }

    public class ConsultaConvenioViewModel
    {
        public int ConvenioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataInclusao { get; set; }
        public int Ativo { get; set; }
       
    }
}
