using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Service
{
    public interface IContatoService
    {
        CommandInput Converter(HttpMethod Method, string Controle = null, ContatoViewModel model = null);      
        Task<CommandResult> Novo(ContatoViewModel model);
        Task<CommandResult> SalvarContatoPaciente(ContatoPacienteViewModel modelPaciente);
    }
}
