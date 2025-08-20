using Desafio.Domain.Repositories;
using Desafio.Infraestructure.DataAccess;

namespace Desafio.Infrastructure.DataAcess;
public class UnitOfWork : IUnitOfWork
{
    private readonly DesafioDbContext _dbContext;
    public UnitOfWork(DesafioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
