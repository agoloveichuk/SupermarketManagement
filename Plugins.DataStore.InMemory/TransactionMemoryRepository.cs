using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DaraStorePluginInterfaces;
using CoreBusiness;

namespace Plugins.DataStore.InMemory
{
    public class TransactionMemoryRepository : ITransactionRepository
    {
        private List<Transaction> transactions;
        public TransactionMemoryRepository()
        {
            transactions = new List<Transaction>();
        }
        public IEnumerable<Transaction> GetByDay(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Save(string cashierName, int productId, double price, int qty)
        {
            int transactionId = 0;
            if (transactionId != 0 && transactions.Count > 0)
            {
                int maxId = transactions.Max(x => x.TransactionId);
                transactionId = maxId + 1;
            }
            else
            {
                transactionId = 1;
            }

            transactions.Add(new Transaction
            {
                TransactionId = transactionId,
                ProductId = productId,
                TimeStamp = DateTime.Now,
                Price = price,
                Qty = qty,
                CashierName = cashierName
            });
        }
    }
}
