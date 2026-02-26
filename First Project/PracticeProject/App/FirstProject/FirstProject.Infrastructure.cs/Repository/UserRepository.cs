using FirstProject.domain.cs.Entities;
using FirstProject.domain.cs.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Infrastructure.cs.Repository
{
    public class UserRepository : IUserInterface
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }//dakho data ab hmara responsedatamodel ka data ma aya hy// //hmm a s//mjhab ma ap ko aik new api create krka dikhata hn jaldi sy dobrsa triqa hy responsedatamodel ko use krny ka //ya zra comple tha//okey//ok//ajao

        public async Task CreateUser(User model)
        {
            await _context.Users.AddAsync(model);    //f11 kro 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(User model)
        {
            var deletedata = await _context.Users
                .FirstOrDefaultAsync(x => x.ID == model.ID);

            if (deletedata != null)
            {
                _context.Users.Remove(deletedata);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetList()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task UpdateUser(User model)
        {
            var updatedData = await _context.Users
                .FirstOrDefaultAsync(x => x.ID == model.ID);

            if (updatedData != null)
            {
                updatedData.UserName = model.UserName;
                updatedData.Name = model.Name;
                updatedData.HashPassword = model.HashPassword;
                updatedData.Gmail = model.Gmail;
                

                _context.Users.Update(updatedData);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> LoginUser(string username, string password)//kl sy dimagh kharab kia howa hy hashpassword property thi
        {
            var result= await _context.Users.Where(x=>x.UserName==username && x.HashPassword==password).FirstOrDefaultAsync();// ai samjh hm ny returrkiya tha
              //ku ka dfatabase ma hy  hi nhi                                                                                                                //ha jb user login kry ga yaha check ka bd user ko koi response to jay ga login hogia hy ach
            return result;
        }
    }
}//ok yaha tk ok//yaha databse match krka bata hy result ma agr table row hy to pori row ko laykr atta hy ok ok
                 