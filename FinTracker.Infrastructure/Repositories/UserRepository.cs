using FinTracker.Domain.Entities;
using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Infrastructure.Database;

namespace FinTracker.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
