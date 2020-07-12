using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ui.portal.jenn.Handler
{
    
    public class CommandResult : ICommandResult
    {

        public CommandResult(bool success, string message, object data, HttpStatusCode status)
        {
            Success = success;
            Message = message;
            Data = data;
            Status = status;
        }
 

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
