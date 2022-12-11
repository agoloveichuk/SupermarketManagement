using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DaraStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;
        public ProductInMemoryRepository()
        {
            // Add some default products 
            products = new List<Product>()
            {
                new Product{ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99},
                new Product{ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 100, Price = 1.99},
                new Product{ProductId = 3, CategoryId = 1, Name = "Bread", Quantity = 100, Price = 1.99},
                new Product{ProductId = 4, CategoryId = 1, Name = "Chease", Quantity = 100, Price = 1.99}
            };
        }
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}
