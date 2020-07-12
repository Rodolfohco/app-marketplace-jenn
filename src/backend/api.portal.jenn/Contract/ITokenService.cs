using api.portal.jenn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
   public interface ITokenService
    {
        string GenerateToken(LogonViewModel model);
    }
}
