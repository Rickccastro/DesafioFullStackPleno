using Desafio.Domain.Repositories;
using Desafio.Infraestructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Desafio.Infrastructure.DataAcess.Repositories;
public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly DesafioDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public RepositoryBase(DesafioDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task AdicionarListaAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public virtual async Task<T> ObterPorPropriedadeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<T> ObterPorIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> ObterTodosAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task AdicionarAsync(T entity)
    {
            await _dbSet.AddAsync(entity);   
    }

    public virtual async Task AtualizarAsync(T entity)
    {
        _dbSet.Update(entity);
    }

    public virtual async Task RemoverAsync(T entity)
    {
         _dbSet.Remove(entity);
    }
}