using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DaraStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly MarketContext db;
        public ProductRepository(MarketContext db) : base(db)
        {
            this.db = db;
        }

        public IEnumerable<Product> GetAllByCategoryId(int categoryId)
        {
            return db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
