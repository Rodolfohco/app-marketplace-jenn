using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface ICommandResult
    {
        HttpStatusCode Status { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
    public interface ICommandResultViewModel<T>
    {
        bool Success { get; set; }
        string Message { get; set; }
        T Data { get; set; }
        HttpStatusCode Status { get; set; }
    }
}
