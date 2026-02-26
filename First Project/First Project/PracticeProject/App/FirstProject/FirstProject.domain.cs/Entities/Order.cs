using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.domain.cs.Entities
{
    public  class Order
    {
        
        public int Id { get; set; }
        public string? OrderNumber { get; set; }
        public string Customername { get; set; }
        public string Productname { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

    }
    }