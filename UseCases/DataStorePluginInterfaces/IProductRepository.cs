using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetAllByCategoryId(int categoryId);    
    }
}
