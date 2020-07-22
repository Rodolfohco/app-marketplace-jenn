using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Business
{
    public class CidadeBusiness : ICidadeRepository
    {
        private readonly ICidadeRepository repository;
        private readonly ILogger<CidadeBusiness> _logger;
        private readonly IMapper mapper;

        public CidadeBusiness(ILogger<CidadeBusiness> logger, ICidadeRepository _repository, IMapper _mapper)
        {
            this.mapper = _mapper;
            this.repository = _repository;
            this._logger = logger;
        }

        public void Delete(int CidadeID)
        {
            throw new NotImplementedException();
        }

        public Cidade Detail(int EmpresaID, int CidadeID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cidade> Get(int EmpresaID)
        {
            throw new NotImplementedException();
        }

        public Cidade Insert(Cidade model, int EmpresaID)
        {
            throw new NotImplementedException();
        }

        public void Update(Cidade model, int CidadeID, int EmpresaID)
        {
            throw new NotImplementedException();
        }
    }
}
