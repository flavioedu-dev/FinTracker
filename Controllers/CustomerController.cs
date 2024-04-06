using FinTracker.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    [HttpGet("{username}")]
    public IActionResult GetCustomer(string username)
    {

        return Ok();
    }

    [HttpPost]
    public IActionResult AddCustomer(CustomerModel customerModel)
    {

        return Ok(customerModel);
    }
}