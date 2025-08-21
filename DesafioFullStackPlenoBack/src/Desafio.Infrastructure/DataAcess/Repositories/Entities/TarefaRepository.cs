using Desafio.Domain.Entities;
using Desafio.Domain.Repositories.Especificas;
using Desafio.Infraestructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infrastructure.DataAcess.Repositories.Entities;
public class TarefaRepository : RepositoryBase<Tarefa>, ITarefaRepository
{
    public TarefaRepository(DesafioDbContext context) : base(context)
    {
    }

    public virtual async Task<List<Tarefa>> ObterUltimasCincoAsync()
    {
        return await _dbSet
            .AsNoTracking()                 
            .OrderByDescending(t => t.DataCriacao) 
            .Take(5)                             
            .ToListAsync();                     
    }
}
