using FirstProject.domain.cs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.domain.cs.Interface
{
    public  interface ITransactionInterface
    {
        Task<List<TransactionData>> GetAllAsync();
        Task<TransactionData> GetByIdAsync(int id);
        Task AddAsync(TransactionData transaction);
        Task<List<TransactionData>> GetByOrderIdAsync(int orderId);
        Task<decimal?> GetTotalSalesAsync();
    }
}
