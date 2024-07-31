using FinTracker.API.Models;
using FinTracker.API.Models.User;
using FinTracker.Domain.DTO;
using FinTracker.Domain.DTO.Response.User;
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
    public IActionResult GetUser(GetUserModel getUserModel)
    {
        GetUserResponseDTO getUserResponseDTO = _userService.GetUser(getUserModel.Id);

        return StatusCode(StatusCodes.Status200OK, getUserResponseDTO);
    }

    [HttpPost]
    public IActionResult AddUser(CreateUserModel userModel)
    {
        RegisterUserDTO registerUserDTO = userModel.Adapt<RegisterUserDTO>();

        RegisterUserResponseDTO registerUserResponseDTO = _userService.RegisterUser(registerUserDTO);

        return StatusCode(StatusCodes.Status201Created, registerUserResponseDTO);
    }
}