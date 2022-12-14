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
        void AddProduct(Product product);
        Product GetProductById(int productId);
        IEnumerable<Product> GetProducts();
        void UpdateProduct(Product product);
        void DeleteProduct (int productId);
    }
}
