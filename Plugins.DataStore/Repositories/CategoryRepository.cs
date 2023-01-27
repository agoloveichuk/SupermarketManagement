using CoreBusiness;

namespace Plugins.DataStore.SQL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(MarketContext context) : base(context)
        {
        }
    }
}
