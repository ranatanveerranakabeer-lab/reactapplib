using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.domain.cs.Entities
{
   public class Product {//okey ai samjh product table ma order or customer ki id hogi to product data fetch kry ga indono ka hmm a gyi smjh thk 
                         //ai samjh yado forign key hogi order or cutomer table ki yaha thk h yh bht mushkil sy likhny dy  rhaa bht slow h //jb ma likho ostime ap isko nhi move kia kro ok 
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? SKU { get; set; }
        public decimal Price { get; set; }
        public decimal StockQuantity { get; set; }


    }


    }

