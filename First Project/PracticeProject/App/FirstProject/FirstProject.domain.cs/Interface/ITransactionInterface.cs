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
       Task<List<Transaction>> GetAll();

      Task<Transaction> GetById(Guid id);

       Task UpdateTransaction(Transaction model);

       Task DeleteTransaction(Transaction model);

       Task CreateTransaction(Transaction model);
    }
}
