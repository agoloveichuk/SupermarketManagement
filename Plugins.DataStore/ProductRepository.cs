using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DaraStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketContext db;
        public ProductRepository(MarketContext db)
        {
            this.db = db;
        }
        public void Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delete(int productId)
        {
            var product = db.Products.Find(productId);
            if (product == null) return;

            db.Products.Remove(product);
            db.SaveChanges();
        }

        public Product GetById(int productId)
        {
            return db.Products.Find(productId);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public IEnumerable<Product> GetAllByCategoryId(int categoryId)
        {
            return db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            var prod = db.Products.Find(product.ProductId);
            prod.Name = product.Name;
            prod.CategoryId = product.CategoryId;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;

            db.SaveChanges();
        }
    }
}
