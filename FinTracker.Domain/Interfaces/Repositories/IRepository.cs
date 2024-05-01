using System.Linq.Expressions;

namespace FinTracker.Domain.Interfaces.Repositories;

public interface IRepository<T>
{
    T? Get(Expression<Func<T, bool>> predicate);
    T? Add(T entity);
    T? Update(T entity);
    T? Delete(T entity);
}