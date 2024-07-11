using FinTracker.Application.Resources;
using FinTracker.Domain.DTO;
using FinTracker.Domain.DTO.Response;
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

    public UserResponseDTO GetUser(int userId)
    {
        try
        {
            User? userRegistered = _userRepository.Get(x => x.Id == userId)
                ?? throw new UserException(HttpStatusCode.NotFound, ApplicationMessages.GetUser_Fail);

            string userJson = JsonSerializer.Serialize(userRegistered);

            UserResponseDTO userResponseDTO = JsonSerializer.Deserialize<UserResponseDTO>(userJson)!;

            return userResponseDTO;
        }
        catch
        {
            throw;
        }
    }

    public UserResponseDTO RegisterUser(UserDTO userDto)
    {
        try
        {
            User user = userDto.Adapt<User>();

            User? userRegistered = _userRepository.Add(user!);

            UserResponseDTO userResponseDTO = userRegistered.Adapt<UserResponseDTO>();

            return userResponseDTO;
        }
        catch (Exception ex)
        {
            throw new UserException(HttpStatusCode.BadRequest, ApplicationMessages.RegisterUser_Fail, ex);
        }
    }
}
