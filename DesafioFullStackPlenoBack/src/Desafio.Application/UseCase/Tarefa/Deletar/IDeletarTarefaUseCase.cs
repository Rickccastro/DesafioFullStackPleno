using Desafio.Communication.Requests.Tarefa;
using Desafio.Communication.Responses.Tarefa;

namespace Desafio.Application.UseCase.Tarefa.Deletar;
public interface IDeletarTarefaUseCase
{
    Task<TarefaResponse> DeletarTarefa(Guid request);
}
