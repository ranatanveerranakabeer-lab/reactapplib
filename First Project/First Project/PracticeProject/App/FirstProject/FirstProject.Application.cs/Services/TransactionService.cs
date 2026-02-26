using FirstProject.Application.cs.Interface;
using FirstProject.domain.cs.Entities;
using FirstProject.domain.cs.Interface;
using FirstProject.Infrastructure.cs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FirstProject.Application.cs.Services
{
   public class TransactionService : ITransactionService
    {
     
            private readonly ITransactionInterface _transactionRepository;

            public TransactionService(ITransactionInterface transactionRepository)
            {
                _transactionRepository = transactionRepository;
            }

            public async Task<TransactionData> CreateTransactionAsync(TransactionData model)
            {
                //var tax = amount * 0.05m;          
                //var discount = amount * 0.02m; 
                //var netAmount = amount + tax - discount;

                //var transaction = new TransactionData
                //{
                //    OrderId = orderId,
                //    TransactionType = "Payment",
                //    ReferenceNumber = "PAY-" + DateTime.Now.Ticks,
                //    Amount = amount,
                //    TaxAmount = tax,
                //    DiscountAmount = discount,
                //    NetAmount = netAmount,
                //    PaymentMethod = paymentMethod,
                //    Status = "Completed",
                //    Remarks = "Auto generated payment",
                //    TransactionDate = DateTime.Now,
                //    CreatedAt = DateTime.Now,
                //    CreatedBy = "System"
                //};

                await _transactionRepository.AddAsync(model);

                return model;
            }

            public async Task<List<TransactionData>> GetTransactionsAsync()
            {
                return await _transactionRepository.GetAllAsync();
            }

           
            public async Task<object> GetSalesReportAsync(DateTime fromDate, DateTime toDate)
            {
                var transactions = await _transactionRepository.GetAllAsync();

                var filtered = transactions.Where(t => t.TransactionDate >= fromDate && t.TransactionDate <= toDate && t.Status == "Completed");
            
                var report = new
                {
                    TotalTransactions = filtered.Count(),
                    TotalAmount = filtered.Sum(t => t.Amount),
                    TotalTax = filtered.Sum(t => t.TaxAmount),
                    TotalDiscount = filtered.Sum(t => t.DiscountAmount),
                    NetRevenue = filtered.Sum(t => t.NetAmount)
                };

                return report;
            }
        }

    }

