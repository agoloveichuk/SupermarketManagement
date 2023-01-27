using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces.CategoryUseCaseInterface;

namespace UseCases.CategoriesUseCase
{
    public class ViewCategoriesUseCase : IViewCategoriesUseCase
    {
        private readonly IGenericRepository<Category> categoryRepository;

        public ViewCategoriesUseCase(IGenericRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> Execute()
        {
            return categoryRepository.GetAll();
        }
    }
}
