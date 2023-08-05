namespace ContosoUniversity.Server.Core.IRepositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
    Task<bool> Create(T entity);
    bool Delete(T entity);
}