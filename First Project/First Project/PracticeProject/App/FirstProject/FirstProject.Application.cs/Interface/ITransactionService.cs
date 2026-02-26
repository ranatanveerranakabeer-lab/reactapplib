using FirstProject.domain.cs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FirstProject.Application.cs.Interface
{
    public interface ITransactionService
    {
        Task<TransactionData> CreateTransactionAsync(TransactionData model);
        Task<List<TransactionData>> GetTransactionsAsync();
        Task<object> GetSalesReportAsync(DateTime fromDate, DateTime toDate);
    }
}
