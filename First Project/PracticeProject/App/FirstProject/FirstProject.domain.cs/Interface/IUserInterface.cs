using FirstProject.domain.cs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.domain.cs.Interface
{
    public interface IUserInterface
    {
        Task<List<User>> GetAll();

        Task<User> GetById(int id);

        Task UpdateUser(User model);

        Task DeleteUser(User model);

        Task CreateUser(User model);
        Task<User> LoginUser(string username, string password);
    }
}
