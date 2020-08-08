
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn.Models
{
    public class NovoProcedimentoViewModel
    {

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public string ImgProduto_Proc { get; set; }

        public int Ativo { get; set; }

        public int  TipoProcedimentoId { get; set; }
    }




    public class ProcedimentoViewModel
    {

        public int ProcedimentoID { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public string ImgProduto_Proc { get; set; }

        public int Ativo { get; set; }

        public TipoProcedimentoViewModel TipoProcedimento { get; set; }
    }
}
