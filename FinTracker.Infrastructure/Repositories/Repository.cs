using FinTracker.Domain.Interfaces.Repositories;
using FinTracker.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinTracker.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public Repository (AppDbContext context)
    {
        _context = context;
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().FirstOrDefault(predicate);
    }

    public T? Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();

        return entity;
    }

    public T? Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();

        return entity;
    }

    public T? Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();

        return entity;
    }
}
