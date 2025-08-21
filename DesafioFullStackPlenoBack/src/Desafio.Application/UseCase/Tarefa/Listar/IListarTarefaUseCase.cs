using Desafio.Communication.Responses.Tarefa;

namespace Desafio.Application.UseCase.Tarefa.Listar;
public interface IListarTarefaUseCase
{
    Task<List<TarefaResponse>> ListarTarefa();
}
