using FirstProject.Application.cs.Interface;
using FirstProject.Application.cs.Model;
using FirstProject.domain.cs.Entities;
using FirstProject.domain.cs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Application.cs.Services
{
    public class UserService:IUserService
    {
        private readonly IUserInterface _userInterface;
        public UserService(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public Task<ResponseModel<User>> AddProduct(User model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<User>> AddUser(User model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<bool>> DeleteUser(int id)
        {  
             var response=new ResponseModel<bool>();  //ya respons  line  mn apny kiya ky//ya dakho hm response ko initialze to kry thy but user pss nhi kia tha//ab hm bool sy bh krty hy ok
            try
            {             
                var result = await _userInterface.GetById(id);//ab thk hoga i thinke hm null baj rahy thy
                if (result != null)
                    response.Success = true;
                response.Message = "Data found successfully";
                await _userInterface.DeleteUser(result); 
                  
            }
            catch (Exception ex)
            {

                response.Success= false;
                response.Message = ex.Message;
                response.Data = true;

            }
            return response;  //sorry yr bool tha true ya false hota hy
        }

        public Task<ResponseModel<List<User>>> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<User>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> LoginUser(string username, string password)
        {
           var result= await _userInterface.LoginUser(username ,password); //ya do demand kry gy ku ka pichy do pss kiye wrn aer
            return result;
           
        }

        public Task<ResponseModel<User>> UpdateUser(int id, User model)
        {
            throw new NotImplementedException();
        }
        //isko bd ma dakthy dosry way ma//aik mint charges khatm horahi aik mint do charger lga lo

    }
}
