using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Service
{
    public interface ILogonService
    {

        CommandInput Converter(HttpMethod Method, string Controle = null, ContatoViewModel model = null);
        CommandInput Converter(HttpMethod Method, string Controle = null, AutenticarLogonViewModel model = null);
        CommandInput Converter(HttpMethod Method, string Controle = null, NovoLogonViewModel model = null);
        
        Task<CommandResult> LocalizarUsuario(AutenticarLogonViewModel model);


        Task<CommandResult> Novo(ContatoViewModel model);
        Task<CommandResult> Novo(NovoLogonViewModel model);
        Task<CommandResult> Detalhar(ConsultaLogonViewModel logon);
        Task<CommandResult> Detalhar(ContatoViewModel contato);

    }

}
