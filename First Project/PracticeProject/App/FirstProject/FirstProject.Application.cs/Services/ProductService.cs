using FirstProject.Application.cs.Interface;
using FirstProject.Application.cs.Model;
using FirstProject.domain.cs;
using FirstProject.domain.cs.Entities;
using FirstProject.domain.cs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace FirstProject.Application.cs.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductInterface _productRepository;
    //ap ny chnge krwaii thee
        //yaha pr galt kia hy  hm ny ap service interface pss krrahi 
        public ProductService(IProductInterface productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseModel<Product>> AddProduct(Product model)
        {
            await _productRepository.CreateProduct(model);//ispr akr phir f11 press krna hy //abhi f10 kro
            return ResponseModel<Product>.SuccessResponse(model, "Data Created Successfully");//
        }

        public async Task<ResponseModel<bool>> DeleteProduct(Guid id)
        {

            var deletedata = await _productRepository.GetById(id);

            if (deletedata != null)
            {

                return ResponseModel<bool>.SuccessResponse(true, "Product deleted successfully");
            }

            return ResponseModel<bool>.FailureResponse("Product not found");

        }


        public async Task<ResponseModel<List<Product>>> GetAllProduct()
        {
            var getlist = await _productRepository.GetAll();
            var product = getlist.Select(a => new Product()
            {
               Name =a.Name,
                Price =a.Price
            }).ToList();
            return ResponseModel<List<Product>>.SuccessResponse(product);
        }

        public async Task<ResponseModel<Product>> GetById(Guid id)
        {
            var product = await _productRepository.GetById(id);
            if (product != null)
            {
                return ResponseModel<Product>.SuccessResponse(product, "Product found successfully");
            }
            return ResponseModel<Product>.FailureResponse("Product not found");
        }

       
        //ap main project ma ajao,ko //bs is mn yhi add krny method
        //perfect hogia okeyp main //hmmmproductcontr
        //id remove krdi thee//aik new controlor create kro api ka liye 
        public  async Task<ResponseModel<Product>> UpdateProduct(Guid id,Product model)
        {
            var updateProduct = await _productRepository.GetById(id);
            //aik mint wait
            if (updateProduct == null)
            {
                return ResponseModel<Product>.FailureResponse("Product not found");
                //ab thk hogia
                updateProduct.Name = model.Name;
                updateProduct.Price = model.Price;
                updateProduct.SKU=model.SKU;
                updateProduct.StockQuantity=model.StockQuantity;
               
                await _productRepository.UpdateProduct(updateProduct);
                
            }
            return ResponseModel<Product>.SuccessResponse(model, "Product updated successfully"); throw new NotImplementedException();
        }
    }
}

