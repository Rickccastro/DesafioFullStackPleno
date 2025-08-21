using Desafio.Communication.Requests.Tarefa;
using Desafio.Communication.Responses.Tarefa;

namespace Desafio.Application.UseCase.Tarefa.Criar;
public interface ICriarTarefaUseCase
{
    Task<TarefaResponse> CriarTarefa(CriarTarefaRequest request);
}
