using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.domain.cs.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string? UserName { get; set; }//ya warning dyraha hy ka null nhi hy hm kahty hy filhal ya null be hosakti hy//
        public string? HashPassword { get; set; }//ispr bd ma jwt lgay gy hashpassword pr 
        public String? Name { get; set; }
        public string? Gmail { get; set; }
    }
}
