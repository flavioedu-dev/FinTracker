using FinTracker.Domain.DTO;
using FinTracker.Domain.DTO.Response.User;

namespace FinTracker.Domain.Interfaces.Services;

public interface IUserService
{
    GetUserResponseDTO GetUser(int userId);

    RegisterUserResponseDTO RegisterUser(RegisterUserDTO user);
}
