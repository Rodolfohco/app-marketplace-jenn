﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewModel
{
    public class ProcedimentoEmpresaViewModel
    {

        public int procedimentoEmpresaID { get; set; }
        public DateTime dataInclusao { get; set; }
        public string nome_pers { get; set; }
        public decimal precoProduto { get; set; }
        public decimal preco_contra { get; set; }
        public string taxaParcelamento { get; set; }
        public string taxaResultado { get; set; }
        public string imagemThumb { get; set; }
        public string imagemHome { get; set; }
        public string imagemMain { get; set; }
        public string video { get; set; }
        public int ativo { get; set; }
        public int? destaque { get; set; }
        public ProcedimentoDestaque procedimento { get; set; }


    }



    public class ProcedimentoDestaque
    {
        public int procedimentoID { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string imgProduto_Proc { get; set; }
        public int ativo { get; set; }
    }

}
