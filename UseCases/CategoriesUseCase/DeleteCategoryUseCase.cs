using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DaraStorePluginInterfaces;
using UseCases.UseCaseInterfaces.CategoryUseCaseInterface;

namespace UseCases.CategoriesUseCase
{
    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
    {
        private readonly IGenericRepository<Category> categoryRepository;

        public DeleteCategoryUseCase(IGenericRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void Execute(int categoryId)
        {
            categoryRepository.Delete(categoryId);
        }
    }
}
