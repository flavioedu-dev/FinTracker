using FinTracker.Application.Resources;
using FinTracker.Domain.DTO;
using FinTracker.Domain.DTO.Response.User;
using FinTracker.Domain.Entities;
using FinTracker.Domain.Exceptions;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using Mapster;
using System.Net;
using System.Text.Json;

namespace FinTracker.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public GetUserResponseDTO GetUser(int userId)
    {
        try
        {
            User? userRegistered = _userRepository.Get(x => x.Id == userId)
                ?? throw new UserException(HttpStatusCode.NotFound, ApplicationMessages.GetUser_Fail);

            GetUserResponseDTO userResponseDTO = userRegistered.Adapt<GetUserResponseDTO>();

            return userResponseDTO;
        }
        catch
        {
            throw;
        }
    }

    public RegisterUserResponseDTO RegisterUser(RegisterUserDTO userDto)
    {
        try
        {
            User user = userDto.Adapt<User>();

            User? userRegistered = _userRepository.Add(user!);

            RegisterUserResponseDTO userResponseDTO = userRegistered.Adapt<RegisterUserResponseDTO>();

            return userResponseDTO;
        }
        catch (Exception ex)
        {
            throw new UserException(HttpStatusCode.BadRequest, ApplicationMessages.RegisterUser_Fail, ex);
        }
    }
}
