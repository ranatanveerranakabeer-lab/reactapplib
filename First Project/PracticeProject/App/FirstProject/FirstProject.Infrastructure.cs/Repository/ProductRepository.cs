using FirstProject.domain.cs;
using FirstProject.domain.cs.Entities;
using FirstProject.domain.cs.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstProject.Infrastructure.cs.Repository
{
    public class ProductRepository : IProductInterface
    {
        private readonly DataContext _context;
       

        public ProductRepository(DataContext context)
        {
            _context= context;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _context.Products.Where(p => p.StockQuantity > 0)
     .ToListAsync();
            return products;

        }//dakho data ab hmara responsedatamodel ka data ma aya hy// //hmm a s//mjhab ma ap ko aik new api create krka dikhata hn jaldi sy dobrsa triqa hy responsedatamodel ko use krny ka //ya zra comple tha//okey//ok//ajao

        public async Task CreateProduct(Product model){
      await _context.Products.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        
            
        public  async  Task<List<Product>> GetList()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task UpdateProduct(Product model)
        {
            var updatedata = await _context.Products.FirstOrDefaultAsync(x => x.Id==model.Id);
            if (updatedata!=null)
            {

               updatedata.Id=model.Id;
                updatedata.Name=model.Name;
                updatedata.SKU=model.SKU;
                updatedata.Price=model.Price;
                updatedata.StockQuantity=model.StockQuantity;  //sidra isko open kro doucment ko yaphir ap   

                updatedata.StockQuantity -= quantity;
                _context.Products.Update(updatedata);
                    await _context.SaveChangesAsync();
                }
        }
        public async Task<Product?> GetById(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }//dakho hm ny aik dto nhi bnai thi aik alg class ya database ma table nhi bny ga sirf front ma show krny ka liye bnaya hy ya tino tables ka mixture hoga //tino tables sy data fetch kry ga based on product table

       //  "data": {

        public  async Task DeleteProduct(Product model)
        {
        var deletedata= await _context.Products.FirstOrDefaultAsync(x=>x.Id == model.Id);
            if(deletedata != null)
            {
                     _context.Products.Remove(deletedata);
              await  _context.SaveChangesAsync();

            }
            }
    }

        //ab dakho
        //return await(
        //    from m in _context.Menus
        //    join mp in _context.MenuPermissions on m.Id equals mp.MenuID
        //    join rp in _context.RolePermissions on mp.PermissionID equals rp.PermissionId
        //    where rp.RoleId == roleId
        //    && m.IsActive
        //    select m
        //).Distinct().ToListAsync(cancellationToken);
    }
    

