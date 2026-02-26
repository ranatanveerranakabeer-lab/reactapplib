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
    { 
        private readonly IProductService _productservice;
        
            public  ProductController(IProductService productservice)
        {

            _productservice= productservice;

        }

       
        [HttpGet("getall") ]
        public async Task<IActionResult> GetAll( )
        {
            var result = await _productservice.GetAllProduct();
            return Ok(result);
        }

       

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id )
        {
            var result = await _productservice.GetById(id);
            if (result == null)
                return NotFound(new { Message = $"productID {id} not found" });

            return Ok(result);
        }
    
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Product dto)
        {
            var result = await _productservice.AddProduct(dto);
            return Ok(result);
        }
   
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product dto )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productservice.UpdateProduct(id, dto);

            if (result == null || !result.Success)
                return NotFound(new { Message = $"product with ID {id} not found" });

            return Ok(result);
        }

    
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _productservice.DeleteProduct(id);

            if (result == null || !result.Data)
                return NotFound(new { Message = $"product with ID {id} not found" });

            // Return 204 No Content
            return NoContent();
        }
    }
    }

