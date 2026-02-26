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
        //f10 kro
        public async Task<ResponseModel<Product>> AddProduct(Product model)
        {
            await _productRepository.CreateProduct(model);//ispr akr phir f11 press krna hy //abhi f10 kro
            return ResponseModel<Product>.SuccessResponse(model, "Data Created Successfully");//
        }
        //krti jao f10
        public async Task<ResponseModel<bool>> DeleteProduct(int id)
        {
            var deletedata = await _productRepository.GetById(id);

            if (deletedata == null)
                return ResponseModel<bool>.FailureResponse("Product not found");

            await _productRepository.DeleteProduct(deletedata); // call delete method
            return ResponseModel<bool>.SuccessResponse(true, "Product deleted successfully");
        }


        public async Task<ResponseModel<List<Product>>> GetAllProduct()
        {
            var getlist = await _productRepository.GetAll();
            var product = getlist.Select(a => new Product()
            {
                Id = a.Id,
                Name = a.Name,
                Price = a.Price,
                SKU = a.SKU,
                StockQuantity = a.StockQuantity
            }).ToList();
            return ResponseModel<List<Product>>.SuccessResponse(product);
        }

        public async Task<ResponseModel<Product>> GetById(int id)
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
        public async Task<ResponseModel<Product>> UpdateProduct(int id, Product model)
        {
            var updateProduct = await _productRepository.GetById(id);
            if (updateProduct == null)
            {
                return ResponseModel<Product>.FailureResponse("Product not found");
            }

            // Properly update fields
            updateProduct.Name = model.Name;
            updateProduct.Price = model.Price;
            updateProduct.SKU = model.SKU;
            updateProduct.StockQuantity = model.StockQuantity;

            await _productRepository.UpdateProduct(updateProduct);

            return ResponseModel<Product>.SuccessResponse(updateProduct, "Product updated successfully");
        }
    }
}

