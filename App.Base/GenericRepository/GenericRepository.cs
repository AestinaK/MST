using System.Linq.Expressions;
using App.Base.Extensions;
using App.Base.GenericRepository.Interface;
using App.Base.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace App.Base.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
    {
        predicate ??= x => true;
        return _context.Set<T>().Where(predicate).ToListAsync();
    }

    public Task<T> GetItemAsync(Expression<Func<T, bool>> predicate)=>
         _context.Set<T>().FirstOrDefaultAsync(predicate);


    public T Find(long id) => _dbSet.Find(id);


    public async Task<T> FindAsync(long id) => await _dbSet.FindAsync(id);
    public IQueryable<T> GetQueryable() => _dbSet.AsQueryable();
    
    public async Task<PagedResult<T>> GetPaginatedAsync(Expression<Func<T, bool>> expression = null,
        Func<IQueryable<T>,
                IQueryable<T>>
            callback = null, int page = 1, int limit = 10)
    {
        expression ??= arg => true;
        var queryable = GetPredicatedQueryable(expression);
        queryable = ApplyCallback(queryable, callback);
        return await queryable.PaginateAsync(page, limit);
    }

    public async Task<bool> CheckIfExistAsync(Expression<Func<T,bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    protected IQueryable<T> GetPredicatedQueryable(Expression<Func<T, bool>> expression) =>
        GetQueryable().Where(expression ?? (x => true));

    protected IQueryable<T> ApplyCallback(IQueryable<T> queryable,
        Func<IQueryable<T>, IQueryable<T>> callback = null) =>
        callback == null ? queryable : callback(queryable);
   
}