
using FinTracker.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost("{CustomerId}/customer")]
        public IActionResult GetCustomer(string? customerId, [FromBody] CustomerModel customerModel)
        {
            customerModel.CustomerId = customerId;

            return Ok(customerModel);
        }
    }
}
