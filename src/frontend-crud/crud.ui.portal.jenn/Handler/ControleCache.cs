using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.ui.portal.jenn.Handler
{
    public class ControleCache
    {
        private readonly IConfiguration configuration;



        public IMemoryCache  Cache { get; set; }
        public ControleCache(IConfiguration _configuration)
        {

            this.configuration = _configuration;


            Cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 1024
            });
        }
    }
}
