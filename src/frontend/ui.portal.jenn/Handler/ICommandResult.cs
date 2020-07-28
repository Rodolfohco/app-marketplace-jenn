using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ui.portal.jenn.Handler
{
    public interface ICommandResult
    {
        HttpStatusCode Status { get; set; }
        string Token { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }

    public interface ICommandInput 
    {

        bool Success { get; set; }
        string Message { get; set; }
        string UrlAction { get; set; }
        object Data { get; set; }
        HttpMethod Metodo { get; set; }
    }



  
}
