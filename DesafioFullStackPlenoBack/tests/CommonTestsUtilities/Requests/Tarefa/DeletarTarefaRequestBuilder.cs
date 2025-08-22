using Bogus;
using Desafio.Communication.Requests.Tarefa;

namespace CommonTestsUtilities.Requests.Tarefa;
public class DeletarTarefaRequestBuilder
{
    public static DeletarTarefaRequest Build()
    {
        return new Faker<DeletarTarefaRequest>()
        .RuleFor(t => t.Id, _ => Guid.NewGuid())
        .RuleFor(t => t.Titulo, f => f.Lorem.Sentence(10));
    }
}
