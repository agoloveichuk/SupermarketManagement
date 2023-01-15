using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DaraStorePluginInterfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(object id);
        IEnumerable<T> GetAll();
        T GetById(object id);
    }
}
