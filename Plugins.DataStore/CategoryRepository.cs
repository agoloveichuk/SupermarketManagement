using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DaraStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoryRepository : GenericRepository<Category>
    {
        private readonly MarketContext db;
        public CategoryRepository(MarketContext db) : base(db)
        {
            this.db = db;
        }
    }
}
