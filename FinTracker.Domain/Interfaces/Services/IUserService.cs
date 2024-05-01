using FinTracker.Domain.DTO;

namespace FinTracker.Domain.Interfaces.Services;

public interface IUserService
{
    UserDTO GetUser(string username);
}
