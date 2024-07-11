using FinTracker.Domain.DTO;
using FinTracker.Domain.DTO.Response;

namespace FinTracker.Domain.Interfaces.Services;

public interface IUserService
{
    UserResponseDTO GetUser(int userId);

    UserResponseDTO RegisterUser(UserDTO user);
}
