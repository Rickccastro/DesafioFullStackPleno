using Bogus;
using Desafio.Communication.Requests.Tarefa;

namespace CommonTestsUtilities.Requests.Tarefa;
public class AtualizarTarefaRequestBuilder
{
    public static AtualizarTarefaRequest Build()
    {
        return new Faker<AtualizarTarefaRequest>()
        .RuleFor(t => t.Id, _ => Guid.NewGuid())
        .RuleFor(t => t.Titulo, f => f.Lorem.Sentence(10))
        .RuleFor(t => t.Descricao, f => f.Lorem.Paragraph(30))
        .RuleFor(t => t.DataCriacao, f => DateTime.UtcNow)
        .RuleFor(t => t.Status, _ => "Pendente")
        .Generate();
    }
}
