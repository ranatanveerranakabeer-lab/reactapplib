using FirstProject.domain.cs.Entities;
using FirstProject.domain.cs.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Infrastructure.cs.Repository
{
    public class TransactionRepository : ITransactionInterface
    {
        private readonly DataContext _dataContext;
        public async Task CreateTransaction(Transaction model)
        {          

            await _dataContext.Transactions.AddAsync(model);
          

        }

        public async Task DeleteTransaction(Transaction model)
        {
            var res = await _dataContext.Transactions.FirstOrDefaultAsync(x => x.Id==model.Id);
            if (res!=null)
            {
                _dataContext.Transactions.Remove(res);
                _dataContext.SaveChanges();
            }
        }
        public async Task<List<Transaction>> GetAll()
        {
            return await _dataContext.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetById(Guid id)
        {
            return await _dataContext.Transactions.FindAsync(id);
        }

        public async Task UpdateTransaction(Transaction model)
        {
            var updatedata = await _dataContext.Transactions.FirstOrDefaultAsync(x => x.Id==model.Id);
            if (updatedata!=null)
            {

                updatedata.Id=model.Id;
                updatedata.OrderId=model.OrderId;
                updatedata.TransactionDate=model.TransactionDate;
                updatedata.TransactionType=model.TransactionType;
              

                _dataContext.Transactions.Update(updatedata);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
