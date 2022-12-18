using CoreBusiness;

namespace UseCases.UseCaseInterfaces.CashierConsoleUseCaseInterface
{
    public interface IViewProductsByCategoryId
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}