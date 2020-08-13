using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface IClienteBusiness
    {
        ViewModel.ContatoViewModel InseriContato(ViewModel.NovoContatoViewModel model);
        ViewModel.ContatoViewModel DetalheContato(Expression<Func<DTO.Contato, bool>> where, bool lazzLoader = false);
        void DeletarContato(Expression<Func<DTO.Contato, bool>> where);

        IEnumerable<ViewModel.ContatoViewModel> SelecionarContato(bool lazzLoader = false);
        IEnumerable<ViewModel.ContatoViewModel> SelecionarContato(Expression<Func<DTO.Contato, bool>> where, bool lazzLoader = false);


        ViewModel.ClienteViewModel InserirCliente(ViewModel.ClienteViewModel model);
        ViewModel.ClienteViewModel DetalharCliente(Expression<Func<DTO.Cliente, bool>> where, bool lazzLoader = false);
        void DeletarCliente(Expression<Func<DTO.Cliente, bool>> where);

        IEnumerable<ViewModel.ClienteViewModel> SelecionarCliente(bool lazzLoader = false);
        IEnumerable<ViewModel.ClienteViewModel> SelecionarCliente(Expression<Func<DTO.Cliente, bool>> where, bool lazzLoader = false);

    }
}
