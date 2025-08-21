using Desafio.Communication.Requests.Tarefa;
using Desafio.Communication.Responses.Tarefa;

namespace Desafio.Application.UseCase.Tarefa.Atualizar;
public interface IAtualizarTarefaUseCase
{
    Task<TarefaResponse> AtualizarTarefa(AtualizarTarefaRequest request);
}
