using FinTracker.API.Models;
using FinTracker.Domain.DTO;
using FinTracker.Domain.Interfaces.Services;
using Mapster;
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
        UserResponseDTO user = _userService.GetUser(username);

        return Ok(user);
    }

    [HttpPost]
    public IActionResult AddUser(UserModel userModel)
    {
        UserDTO userDto = userModel.Adapt<UserDTO>();

        UserResponseDTO userResponseDTO = _userService.RegisterUser(userDto);

        return Ok(userResponseDTO);
    }
}