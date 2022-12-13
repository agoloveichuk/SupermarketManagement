using CoreBusiness;

namespace UseCases.UseCaseInterfaces.CategoryUseCaseInterface
{
    public interface IGetCategoryByIdUseCase
    {
        Category Execute(int categoryId);
    }
}