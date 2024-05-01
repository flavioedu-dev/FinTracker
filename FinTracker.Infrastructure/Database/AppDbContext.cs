using FinTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinTracker.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<User> users { get; set; }
    public DbSet<Finance> finances { get; set; }
}