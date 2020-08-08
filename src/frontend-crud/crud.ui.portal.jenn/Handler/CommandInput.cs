using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
 

namespace crud.ui.portal.jenn.Handler
{
    public class CommandInput : ICommandInput
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string UrlAction { get; set; }
        public object Data { get; set; }
        public HttpMethod Metodo { get; set; }
    }
}
