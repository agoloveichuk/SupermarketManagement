using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MarketContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetAllByCategoryId(int categoryId)
        {
            return context.Products.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
