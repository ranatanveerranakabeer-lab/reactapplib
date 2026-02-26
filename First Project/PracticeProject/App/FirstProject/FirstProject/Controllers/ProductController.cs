using FirstProject.Application.cs.Interface;
using FirstProject.Application.cs.Model;
using FirstProject.Application.cs.Services;
using FirstProject.domain.cs;
using FirstProject.domain.cs.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    { //yaha iproduct  service //jb ma  likho phir ap na likho//yhi ref //yaha koi bs veriable  sy intialze krsakti ho ap
        private readonly IProductService _productservice;//yhn koi bhiI//yes koi bh name ra  )//        public ProductController(i)
        
            public  ProductController(IProductService productservice)
        {

            _productservice= productservice;

        }

        // GET: api/v1/payment
        [HttpGet("getall") ]
        public async Task<IActionResult> GetAll( )
        {
            var result = await _productservice.GetAllProduct();
            return Ok(result);
        }

       
        //ab hmy data pproductdto ma araha hy tino table sy based on product 1,ab hm database ma product table ma id 3 dalty hy phir dakhy hy okey kry  oky oky 
            
  //ya query boht use hoti hy reeport bnany ma pdf generate kny ma agy //hm aik order class ki  kl api bnay gy sath delete update read list or fetch ki sirf query sy ap ko or clear hoga phir itni muskil nhi hy kro gi joati hy oky thk h//ma zip file abhi send krta hn kl practice krna agr class nhi hy to
               
               //dakho osy product ma to mili id product ki 4 but order or customer ma to nhi hy na match nhi howi osny data nhi dia laikn api complete process horahi hy

       
        // GET: api/v1/payment/{id}//yr run kro isko //
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(Guid id )
        {
            var result = await _productservice.GetById(id);
            if (result == null)
                return NotFound(new { Message = $"productID {id} not found" });

            return Ok(result);
        }
       ///data hmara add  hogia tha//breakpoint pr ku nhi aya add krty hy// na hi get pr akr ruka rukna chaye tha
        // POST: api/v1/payment
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Product dto)
        {
            var result = await _productservice.AddProduct(dto);
            return Ok(result);
        }//f10 press kro//ab agy jana hy service ma jaha method ho waha pr f11 press kro ab//yaha pr f11 press kro
        //create ko simple krdia hy abhiS 

        /// <summary>
        /// /yr isko dobara chaloa nhi kia iisue file pori load nhi krta 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// PUT: api/v1/payment/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Product dto )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);//write kro //oky

            var result = await _productservice.UpdateProduct(id, dto);

            if (result == null || !result.Success)
                return NotFound(new { Message = $"product with ID {id} not found" });

            return Ok(result);
        }

        // DELETE: api/v1/payment/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _productservice.DeleteProduct(id);

            if (result == null || !result.Data)
                return NotFound(new { Message = $"product with ID {id} not found" });

            // Return 204 No Content
            return NoContent();
        }
    }
    }

