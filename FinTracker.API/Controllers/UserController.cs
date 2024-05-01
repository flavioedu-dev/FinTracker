using FinTracker.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("{username}")]
    public IActionResult GetUser(string username)
    {


        return Ok();
    }

    [HttpPost]
    public IActionResult AddUser(UserModel userModel)
    {

        return Ok(userModel);
    }
}