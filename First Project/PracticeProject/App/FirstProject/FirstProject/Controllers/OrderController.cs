using FirstProject.Application.cs.Interface;
using FirstProject.Application.cs.Model;
using FirstProject.Application.cs.Services;
using FirstProject.domain.cs.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderService.GetAllOrder();
            return Ok(result);
        }
        [HttpGet("getallcustomerorderproduct")]
        public async Task <ResponseModel> getallcustomerorderproduct(Guid id) { 
        ResponseModel response = new ResponseModel();
            var result = await _orderService.GetAllCustomerOrder(id);
            if (result == null)
            {
                response.IsSuccess=false;
                response.Message="id not match in product or customer or order";
                response.Data=null;
                return response;
            }
            else
            {
                response.IsSuccess=true;
                response.Message="data fetch successfully";
                response.Data=new List<object>
                {result };
                return response;
            }



            }    
        
       






        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _orderService.GetById(id);
            if (result == null)
                return NotFound(new { Message = $"orderID {id} not found" });

            return Ok(result);
        }

        // POST: api/v1/payment
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Order dto)
        {
            var result = await _orderService.AddOrder(dto);
            return Ok(result);

        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Order dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);//write kro //oky

            var result = await _orderService.UpdateOrder(id, dto);

            if (result == null || !result.Success)
                return NotFound(new { Message = $"order with ID {id} not found" });

            return Ok(result);
        }

        // DELETE: api/v1/payment/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _orderService.DeleteOrder(id);

            if (result == null || !result.Data)
                return NotFound(new { Message = $"order with ID {id} not found" });

            // Return 204 No Content
            return NoContent();
        }
    }
}
