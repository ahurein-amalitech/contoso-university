using ContosoUniversity.Server.Core.IConfiguration;
using ContosoUniversity.Server.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Server.Data;

public class UnitOfWork : IUnitOfWork , IDisposable
{
    public IStudentRepository Students { get; set; }
    private DbContext _context;

    public UnitOfWork(SchoolContext context)
    {
        _context = context;
        Students = new StudentRepository(context);
    }

    public async Task CommitChangesToDb()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}