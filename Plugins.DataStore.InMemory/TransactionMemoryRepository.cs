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

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions;
            else
                return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
            return transactions;
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
                return transactions.Where(x => 
                string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) &&
                x.TimeStamp.Date == date.Date);
        }

        public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
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
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName
            });
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            else
                return transactions.Where(x =>
                string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) &&
                x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
        }
    }
}
