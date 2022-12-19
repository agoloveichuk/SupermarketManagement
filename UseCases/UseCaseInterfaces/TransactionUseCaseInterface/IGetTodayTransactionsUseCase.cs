using CoreBusiness;

namespace UseCases.UseCaseInterfaces.TransactionUseCaseInterface
{
    public interface IGetTodayTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName);
    }
}