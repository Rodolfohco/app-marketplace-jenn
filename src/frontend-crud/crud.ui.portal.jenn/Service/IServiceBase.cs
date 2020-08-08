using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud.ui.portal.jenn.Handler;

namespace crud.ui.portal.jenn.Service
{
    public interface IServiceBase
    {

        Task<ICommandResult> PutAsync(ICommandInput model);
        Task<ICommandResult> PostAsync(ICommandInput model);
        Task<ICommandResult> DetailAsync(ICommandInput model);
        Task<ICommandResult> GetAsync(ICommandInput model);
        Task<ICommandResult> DeleteAsync(ICommandInput model);
    }
}
