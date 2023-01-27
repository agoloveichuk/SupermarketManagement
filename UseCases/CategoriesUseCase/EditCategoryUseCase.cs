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
    public class EditCategoryUseCase : IEditCategoryUseCase
    {
        private readonly IGenericRepository<Category> categoryRepository;

        public EditCategoryUseCase(IGenericRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void Execute(Category category)
        {
            categoryRepository.Update(category);
        }
    }
}
