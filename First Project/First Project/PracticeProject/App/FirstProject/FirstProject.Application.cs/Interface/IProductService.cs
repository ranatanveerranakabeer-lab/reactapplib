using FirstProject.Application.cs.Model;
using FirstProject.domain.cs;
using FirstProject.domain.cs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Application.cs.Interface
{ 
    public interface IProductService
    {

        Task<ResponseModel<List<Product>>> GetAllProduct();
   
        Task<ResponseModel<Product>> GetById(int id);
        
        Task<ResponseModel<bool>> DeleteProduct(int id);

        Task<ResponseModel<Product>> UpdateProduct(int id,Product model);


        Task<ResponseModel<Product>> AddProduct(Product model);
        

    }
}
