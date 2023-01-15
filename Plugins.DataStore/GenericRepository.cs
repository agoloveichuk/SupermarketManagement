using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DaraStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MarketContext db;
        public DbSet<T> table = null;

        public GenericRepository(MarketContext db)
        {
            this.db = db;
            table = this.db.Set<T>();
        }
        public void Add(T obj)
        {
            table.Add(obj);
            db.SaveChanges();
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
