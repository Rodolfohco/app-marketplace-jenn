﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Service
{
    public interface IEmpresaService
    {
        CommandInput Converter(HttpMethod Method, EmpresaViewModel model = null);
        Task<CommandResult> Selecionar();
        Task DeletarAsync(Guid EmpresaID);

        Task<CommandResult> Novo(EmpresaViewModel model);

        Task Atualizar(EmpresaViewModel model, Guid EmpresaID);
        Task<CommandResult> Detalhar(Guid EmpresaID);
    }
}
