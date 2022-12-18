namespace UseCases.UseCaseInterfaces.CashierConsoleUseCaseInterface
{
    public interface ISellProductUseCase
    {
        void Execute(int productId, int qtyToSell);
    }
}