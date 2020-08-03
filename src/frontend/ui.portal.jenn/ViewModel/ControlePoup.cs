using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ui.portal.jenn.ViewModel
{
    public enum TipoMensagem
    {
        Aviso, 
        Confirmacao, 
        Erro
    }
    public class ControlePoup
    {
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public TipoMensagem Tipo { get; set; }
    }
}
