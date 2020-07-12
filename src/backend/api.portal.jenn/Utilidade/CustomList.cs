using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace api.portal.jenn.Utilidade
{

    


    public abstract class CustomList<TModel> : IEnumerable<TModel>
        where TModel: class
    {
        private IEnumerable<TModel>  lista;
        public CustomList(IEnumerable<TModel> _lista)
        {
            
        }
        public IEnumerable<TModel> GetPagination(int? page, int pageSize)
        {
            lista.Skip((page ?? 0) * pageSize).Take(pageSize).AsEnumerable();
            return lista;
        }
        public IEnumerator<TModel> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
