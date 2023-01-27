
namespace UseCases.DataStorePluginInterfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
    }
}
