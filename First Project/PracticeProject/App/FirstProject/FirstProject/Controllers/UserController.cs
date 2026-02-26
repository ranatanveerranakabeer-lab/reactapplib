using FirstProject.Application.cs.Interface;
using FirstProject.Application.cs.Model;
using FirstProject.Application.cs.Services;
using FirstProject.domain.cs.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase//kry aggy haha///yh bhi usii trah hi huga // is line ma kia agy ga gay
    {
        private readonly    IUserService _service;//haha
        //ctor sy kia kry
        public UserController(IUserService service )//same nhi rakha kro kry test kia hota hy hmmm
        { 
            _service = service;//hm ny response ma nhi bajh result isi liye
        }

        [HttpPost("login")] //jb ap user ki class pass krty hy like User user iska mtlb hota hy ka user ki sari proerties is ka varaiable ma agy hy waha sy get krlo like model ma user ki agi thi hm ny model .username get kia is ma koi galt hy hm ny is mn user ki class pass ki //yes user ki sari properties a
       //ai samjh//isk obj bna ky pass krn//aisy bh thk hy//pta ap ko sb hy acha //but ya professional nhi hy aisy
        public async Task<ResponseModel> Loginuser([FromBody] User model)
        {
            ResponseModel response = new ResponseModel();
           var result=  await _service.LoginUser(model.UserName, model.HashPassword);//ab error pr nhi jay ga
            if (result == null)//null nhi tha error condition ma nhi gia okey
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Message = "invalid username and password";//ai samjh //hmmm a gyii or kl kry gy ab ap ny practice krni hy//whats app ao
            }
            else
            {
                response.IsSuccess = true;
                response.Data = new List<User>() { result};
                response.Message = "login successfully";
            }

            return (response);    
        }
    }//kro ab enter


}//hogia login simple bnaya hy kl hm kry jwt sy //hello //contnu kry create kro classes ap ma namaz ada krlo ok //okey//kuch khana hy// oky  2 tables jo addd kiy wo dkhyn init tb krn gy jb first time hm migration krn gy yh phr hr dfa //nhi update easy bh hojata hy filhal aisa krty hy delete krka  ma connnd btao ga ap ko
//bolo