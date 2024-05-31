using FinTracker.Domain.DTO;

namespace FinTracker.Domain.Interfaces.Services;

public interface IUserService
{
    UserResponseDTO RegisterUser(UserDTO user);

    UserResponseDTO GetUser(string username);
}
