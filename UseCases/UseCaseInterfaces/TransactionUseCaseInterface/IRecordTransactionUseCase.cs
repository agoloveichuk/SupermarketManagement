namespace UseCases.UseCaseInterfaces.TransactionUseCaseInterface
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string cashierName, int productId, int qty);
    }
}