using FirstProject.Application.cs.Model;
using FirstProject.domain.cs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Application.cs.Interface
{
    public interface IUserService
    {
        Task<ResponseModel<List<User>>> GetAllUser(); 
        Task<ResponseModel<User>> GetById(int id);

        Task<ResponseModel<bool>> DeleteUser(int id);  
        Task<ResponseModel<User>> UpdateUser(int id, User model);
        Task<User> LoginUser(string username, string password);//agr yaha pr ap sirf aik username pass kro gi to ya username ko psskro gy// lakin hm ny respository interface ma do pss kiye hy to yaha do hi pass hogy dakho

        Task<ResponseModel<User>> AddUser(User model);
    }
}
