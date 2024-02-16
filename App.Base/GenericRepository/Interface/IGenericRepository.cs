using System.Linq.Expressions;
using App.Base.ValueObject;

namespace App.Base.GenericRepository.Interface;

public interface IGenericRepository <T> where T : class
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate= null);
    Task<T> GetItemAsync(Expression<Func<T, bool>> predicate);
    T Find(long id);
    Task<T> FindAsync(long id);

    IQueryable<T> GetQueryable();
    Task<PagedResult<T>> GetPaginatedAsync(Expression<Func<T, bool>> expression = null,
        Func<IQueryable<T>,
                IQueryable<T>>
            callback = null, int page = 1, int limit = 10);

    Task<bool> CheckIfExistAsync(Expression<Func<T,bool>> predicate);
}