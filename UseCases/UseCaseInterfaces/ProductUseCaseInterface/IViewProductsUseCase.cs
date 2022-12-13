using CoreBusiness;

namespace UseCases.UseCaseInterfaces.ProductUseCaseInterface
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute();
    }
}