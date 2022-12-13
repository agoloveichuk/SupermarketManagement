using CoreBusiness;

namespace UseCases.UseCaseInterfaces.CategoryUseCaseInterface
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}