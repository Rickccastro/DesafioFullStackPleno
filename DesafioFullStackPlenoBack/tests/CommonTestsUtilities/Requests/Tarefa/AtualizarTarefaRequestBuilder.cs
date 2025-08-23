using Bogus;
using CommonTestsUtilities.Entities;
using Desafio.Communication.Requests.Tarefa;
using Desafio.Domain.Entities;


namespace CommonTestsUtilities.Requests.Tarefa;
public class AtualizarTarefaRequestBuilder
{
    public static AtualizarTarefaRequest Build()
    {
        return new Faker<AtualizarTarefaRequest>()
        .RuleFor(t => t.Id, _ => Guid.NewGuid())
        .RuleFor(t => t.Titulo, f => f.Lorem.Sentence(10))
        .RuleFor(t => t.Descricao, f => "olá")
        .RuleFor(t => t.UsuarioId, f => UsuarioBuilder.Build().Id)
        .RuleFor(t => t.Status, _ => "Pendente")
        .Generate();
    }
}
