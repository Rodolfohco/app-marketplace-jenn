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

        public void Delete(int CidadeID)
        {
            throw new NotImplementedException();
        }

        public Cidade Detail(int UnidadeID, int EmpresaID, int CidadeID)
        {
            throw new NotImplementedException();
        }

        public Cidade Detail(int EmpresaID, int CidadeID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cidade> Get(int UnidadeID, int EmpresaID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cidade> Get(int EmpresaID)
        {
            throw new NotImplementedException();
        }

        public Cidade Insert(Cidade model, int UnidadeID, int EmpresaID)
        {
            throw new NotImplementedException();
        }

        public Cidade Insert(Cidade model, int EmpresaID)
        {
            throw new NotImplementedException();
        }

        public void Update(Cidade model, int CidadeID, int UnidadeID, int EmpresaID)
        {
            throw new NotImplementedException();
        }

        public void Update(Cidade model, int CidadeID, int EmpresaID)
        {
            throw new NotImplementedException();
        }
    }
}
