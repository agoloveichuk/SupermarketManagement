using CoreBusiness;

namespace UseCases.UseCaseInterfaces.ProductUseCaseInterface
{
    public interface IGetProductByIdUseCase
    {
        Product Execute(int productId);
    }
}