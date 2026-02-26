using FirstProject.domain.cs.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Infrastructure.cs
{
    public class DataContext : DbContext//yr control ka sath s dbo save kro
    {
      
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Order> Orders { get; set; }

        //okey samjh arahi hy //is mn hm user ki info ky liy table bna rhyy jo userclass bnaii//ha jo class bnai hy isko ya dbset bnana lazmi hy dbcotext ko pta ho g wgyii lkin is ki nhi hm ny jwt login ky liy user class bnaii or phr table bhi usii ka db mn bny ga //yes jwt bd ma lgay gy wo jb hm password create kry gy like 1234 wo isko  encrypt form ma database ma save kry ga like/eferfherifkerj// okyy

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//f10 krti jao
        }
    }
}
