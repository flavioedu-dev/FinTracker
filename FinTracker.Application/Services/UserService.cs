using FinTracker.Domain.DTO;
using FinTracker.Domain.Entities;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Domain.Interfaces.Services;
using System.Text.Json;

namespace FinTracker.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserDTO GetUser(string username)
    {
        User? userRegistered = _userRepository.Get(x => x.Username == username);

        if (userRegistered is null)
            throw new Exception("User not found.");

        string userJson = JsonSerializer.Serialize(userRegistered);

        UserDTO userDto = JsonSerializer.Deserialize<UserDTO>(userJson)!; 

        return userDto;
    }
}
