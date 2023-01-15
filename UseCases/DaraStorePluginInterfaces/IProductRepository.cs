using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DaraStorePluginInterfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
        IEnumerable<Product> GetAll();
        Product GetById(int productId);
        IEnumerable<Product> GetAllByCategoryId(int categoryId);    
    }
}
