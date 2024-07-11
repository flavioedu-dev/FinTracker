using FinTracker.API.Models;
using FinTracker.Domain.DTO;
using FinTracker.Domain.DTO.Response;
using FinTracker.Domain.Entities;
using FinTracker.Domain.Interfaces.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userId}")]
    public IActionResult GetUser(int userId)
    {
        UserResponseDTO user = _userService.GetUser(userId);

        return StatusCode(StatusCodes.Status200OK, user);
    }

    [HttpPost]
    public IActionResult AddUser(UserModel userModel)
    {
        UserDTO userDto = userModel.Adapt<UserDTO>();

        UserResponseDTO userResponseDTO = _userService.RegisterUser(userDto);

        return StatusCode(StatusCodes.Status201Created, userResponseDTO);
    }
}