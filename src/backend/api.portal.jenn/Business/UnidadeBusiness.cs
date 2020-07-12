using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Business
{
    public class UnidadeBusiness : IUnidadeBusiness
    {

        private readonly IUnidadeRepository repository;
        private readonly ILogger<EmpresaBusiness> logger;
        private readonly IMapper mapper;

        public UnidadeBusiness(IUnidadeRepository _repository, ILogger<EmpresaBusiness> _logger, IMapper _mapper)
        {
            this.repository = _repository;
            this.logger = _logger;
            this.mapper = _mapper;
        }

        public void Atualizar(UnidadeViewModel model, Guid UnidadeId, Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public UnidadeViewModel Detalhar(Func<Unidade, bool> where, Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Expression<Func<Unidade, bool>> where, Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public UnidadeViewModel Inserir(UnidadeViewModel model, Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UnidadeViewModel> Selecionar(Guid EmpresaID)
        {          

            IEnumerable<UnidadeViewModel> retorno = null;
            try
            {
                var unidade = this.repository.Get(EmpresaID);

                if (unidade != null)
                    retorno = this.mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(unidade.AsEnumerable());
                else
                    throw new Exception($"Unidade não Localizado: id do Empresa [{EmpresaID}]");
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
         
    }

        public IEnumerable<UnidadeViewModel> Selecionar(Func<Unidade, bool> where, Guid EmpresaID)
        {
            IEnumerable<UnidadeViewModel> retorno = null;
            try
            {
                var unidade = this.repository.Get(EmpresaID).Where(where);

                if (unidade != null)
                    retorno = this.mapper.Map<IEnumerable<Unidade>, IEnumerable<UnidadeViewModel>>(unidade.AsEnumerable());
                else
                    throw new Exception($"Unidade não Localizado: id do Empresa [{EmpresaID}]");
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }



       

    }
}
