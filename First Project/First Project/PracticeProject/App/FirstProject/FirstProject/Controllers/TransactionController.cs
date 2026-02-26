using FirstProject.Application.cs.Interface;
using FirstProject.domain.cs.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }//hmari kl wali open kro

        [HttpPost]
        public async Task<IActionResult> Create(TransactionData model)
        {
            var result = await _transactionService
                .CreateTransactionAsync(model);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _transactionService.GetTransactionsAsync();
            return Ok(transactions);
        }

        
        [HttpGet("report")]
        public async Task<IActionResult> GetReport(DateTime fromDate, DateTime toDate)
        {
            var report = await _transactionService
                .GetSalesReportAsync(fromDate, toDate);

            return Ok(report);
        }
    }
}
