using FirstProject.Application.cs.Interface;
using FirstProject.domain.cs.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerservice;

        public CustomerController(ICustomerService customerservice)
        {

            _customerservice= customerservice;

        }

       
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerservice.GetAllCustomer();
            return Ok(result);
        }



      
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _customerservice.GetById(id);
            if (result == null)
                return NotFound(new { Message = $"customerID {id} not found" });

            return Ok(result);
        }
       
     
        [HttpPost("create")]//agy move kro f10 sy addcustomer pr f11 krna taka agly method ma jay// f11 press kro dear
        public async Task<IActionResult> Create([FromBody] Customer dto) //ab create kro
        {
            var result = await _customerservice.AddCustomer(dto);  
            return Ok(result);
        }

       
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Customer dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _customerservice.UpdateCustomer(id, dto);

            if (result == null || !result.Success)
                return NotFound(new { Message = $"customer with ID {id} not found" });

            return Ok(result);
        }

       
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _customerservice.DeleteCustomer(id);

            if (result == null || !result.Data)
                return NotFound(new { Message = $"customer with ID {id} not found" });

        
            return NoContent();
        }
    }
}


