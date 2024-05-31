using FinTracker.Domain.DTO;
using FinTracker.Domain.Entities;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using Mapster;
using System.Text.Json;

namespace FinTracker.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserResponseDTO GetUser(string username)
    {
        User? userRegistered = _userRepository.Get(x => x.Username == username);

        if (userRegistered is null)
            throw new Exception("User not found.");

        string userJson = JsonSerializer.Serialize(userRegistered);

        UserResponseDTO userResponseDTO = JsonSerializer.Deserialize<UserResponseDTO>(userJson)!; 

        return userResponseDTO;
    }

    public UserResponseDTO RegisterUser(UserDTO userDto)
    {
        try
        {
            User user = userDto.Adapt<User>();

            User? userRegistered = _userRepository.Add(user!) ?? throw new Exception("User not registered.");

            UserResponseDTO userResponseDTO = userRegistered.Adapt<UserResponseDTO>();

            return userResponseDTO;
        }
        catch
        {
            throw;
        }
    }
}
