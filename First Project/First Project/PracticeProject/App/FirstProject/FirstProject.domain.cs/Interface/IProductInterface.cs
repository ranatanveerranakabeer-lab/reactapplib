using FirstProject.domain.cs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.domain.cs.Interface
{
    public interface IProductInterface
    {
        

        Task<List<Product>> GetAll();

        

        Task<Product>  GetById(int id);

        Task UpdateProduct(Product model);

        Task DeleteProduct(Product model);

      Task   CreateProduct(Product model);
    }
}
