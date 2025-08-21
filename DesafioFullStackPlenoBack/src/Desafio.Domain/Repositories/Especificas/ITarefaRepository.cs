using Desafio.Domain.Entities;

namespace Desafio.Domain.Repositories.Especificas;
public interface ITarefaRepository : IRepositoryBase<Tarefa>
{
   Task<List<Tarefa>> ObterUltimasCincoAsync();     
}
