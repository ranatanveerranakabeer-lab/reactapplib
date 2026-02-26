using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.domain.cs.Entities
{
    public  class TransactionData
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }

        public string? TransactionType { get; set; }  // Payment, Refund, StockIn, StockOut

        public string? ReferenceNumber { get; set; }  // INV-001, PAY-001

        public decimal? Amount { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? NetAmount { get; set; }

        public string? PaymentMethod { get; set; } // Cash, Card, Bank

        public string? Status { get; set; } // Pending, Completed, Failed

        public string? Remarks { get; set; }

        public DateTime? TransactionDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }
    }
}
