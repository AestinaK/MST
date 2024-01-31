using System.Linq.Expressions;
using App.Base.GenericRepository.Interface;
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
}