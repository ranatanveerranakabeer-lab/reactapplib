using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.domain.cs.Entities
{
    public  class Transaction
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string? TransactionType { get; set; } // StockIn, StockOut, Payment
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
