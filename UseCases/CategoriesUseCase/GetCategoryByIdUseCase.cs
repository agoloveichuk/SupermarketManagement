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
    public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
    {
        private readonly ICategoryRepository categoryrepository;

        public GetCategoryByIdUseCase(ICategoryRepository categoryrepository)
        {
            this.categoryrepository = categoryrepository;
        }
        public Category Execute(int categoryId)
        {
            return categoryrepository.GetById(categoryId);
        }
    }
}
