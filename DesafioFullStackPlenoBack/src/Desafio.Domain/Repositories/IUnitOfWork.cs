namespace Desafio.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}