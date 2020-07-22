using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Repository
{
    public class CidadeRepoistory : ICidadeRepository
    {

        private readonly ConvenioContextFactory contexto;
        private readonly ILogger<CidadeRepoistory> logger;
        private readonly IConfiguration configuration;
        public CidadeRepoistory(
            IConfiguration _configuration,
            ILogger<CidadeRepoistory> _logger,
            ConvenioContextFactory _context)
        {
            this.configuration = _configuration;
            this.logger = _logger;
            this.contexto = _context;
        }

        public void Delete(Guid CidadeID)
        {
            throw new NotImplementedException();
        }

        public Cidade Detail(Guid UnidadeID, Guid EmpresaID, Guid CidadeID)
        {
            throw new NotImplementedException();
        }

        public Cidade Detail(Guid EmpresaID, Guid CidadeID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cidade> Get(Guid UnidadeID, Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cidade> Get(Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public Cidade Insert(Cidade model, Guid UnidadeID, Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public Cidade Insert(Cidade model, Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public void Update(Cidade model, Guid CidadeID, Guid UnidadeID, Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public void Update(Cidade model, Guid CidadeID, Guid EmpresaID)
        {
            throw new NotImplementedException();
        }
    }
}
