using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DaraStorePluginInterfaces
{
    public interface ICategoryRepository 
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(int categoryId);
        IEnumerable<Category> GetAll();
        Category GetById(int categoryId);

    } 
}
