using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface IProdutoBusiness
    {
        #region Metodos
        DTO.Produto Inserir(DTO.Produto model);
        IEnumerable<DTO.Produto> Selecionar();
        IEnumerable<DTO.Produto> Selecionar(Expression<Func<DTO.Produto, bool>> where);
        void Excluir(Expression<Func<DTO.Produto, bool>> where);
        void Atualizar(DTO.Produto model, Guid id);
        DTO.Produto Detalhar(Expression<Func<DTO.Produto, bool>> where);

        #endregion
    }
}
