using System.Linq.Expressions;

namespace Desafio.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> ObterPorPropriedadeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> ObterPorIdAsync(Guid id);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task AdicionarAsync(T entity);
        Task AdicionarListaAsync(IEnumerable<T> entities);
        Task AtualizarAsync(T entity);
        Task RemoverAsync(T entity);
    }
}
