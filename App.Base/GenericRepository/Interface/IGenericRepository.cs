using System.Linq.Expressions;

namespace App.Base.GenericRepository.Interface;

public interface IGenericRepository <T> where T : class
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate= null);
    Task<T> GetItemAsync(Expression<Func<T, bool>> predicate);
    T Find(long id);
    Task<T> FindAsync(long id);

    IQueryable<T> GetQueryable();
}