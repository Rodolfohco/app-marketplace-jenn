using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;

namespace ui.portal.jenn.ViewModel
{
    public class AutenticacaoViewModel 
     {
        readonly ICommandResult commandResult;
        private readonly IMemoryCache cache;

        public AutenticacaoViewModel(ControleCache _cache)
        {
         
        }

        public AutenticacaoViewModel(ICommandResult _commandResult)
        {
            this.commandResult = _commandResult;


            if (this.commandResult.Status == HttpStatusCode.OK)
            {
                if (this.commandResult.Data != null && this.commandResult.Data.ToString().Length > 3)
                {
                    string json = this.commandResult.Data.ToString();

                    _usuario = JsonConvert.DeserializeObject<ConsultaLogonViewModel>(json);
                }
                else
                    _usuario = null;
            }
        }

        


        private ConsultaLogonViewModel _usuario;

        public ConsultaLogonViewModel Usuario { get => _usuario; private set => _usuario = value; }
    }
}