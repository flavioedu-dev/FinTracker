using FinTracker.API.Models;
using FinTracker.Domain.DTO;
using FinTracker.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController (IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{username}")]
    public IActionResult GetUser(string username)
    {
        UserDTO user = _userService.GetUser(username);

        return Ok(user);
    }

    [HttpPost]
    public IActionResult AddUser(UserModel userModel)
    {

        return Ok(userModel);
    }
}