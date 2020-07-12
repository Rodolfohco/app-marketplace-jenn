using api.portal.jenn.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace api.portal.jenn
{
    public class CommandResult : ICommandResult
    {

        public CommandResult(bool success, string message, object data, HttpStatusCode  status)
        {
            Success = success;
            Message = message;
            Data = data;
            Status = status;
        }


        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public HttpStatusCode  Status { get; set; }
    }


    public class CommandResultViewModel<TModel> : ICommandResultViewModel<TModel>
    {
        public CommandResultViewModel(bool success, string message, TModel data, HttpStatusCode status)
        {
            Success = success;
            Message = message;
            Data = data;
            Status = status;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public TModel Data { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
