using ContosoUniversity.Server.Core.IRepositories;
using ContosoUniversity.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Server.Core.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbset;
    
    public GenericRepository(SchoolContext context)
    {
        _context = context;
        _dbset = context.Set<T>();
    }
    
    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await _dbset.ToListAsync();
    }

    public virtual async Task<T?> GetById(int id)
    {
        return await _dbset.FindAsync(id);
    }

    public virtual async Task<bool> Create(T entity)
    {
        await _dbset.AddAsync(entity);
        return true;
    }

    public virtual bool Delete(T entity)
    {
         _dbset.Remove(entity);
         return true;
    }
}