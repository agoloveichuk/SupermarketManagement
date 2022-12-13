using CoreBusiness;

namespace UseCases.UseCaseInterfaces.ProductUseCaseInterface
{
    public interface IAddProductUseCase
    {
        void Execute(Product product);
    }
}