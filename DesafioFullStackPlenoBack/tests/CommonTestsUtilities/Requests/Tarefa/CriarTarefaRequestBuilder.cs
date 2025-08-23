using Bogus;
using CommonTestsUtilities.Entities;
using Desafio.Communication.Requests.Tarefa;

namespace CommonTestsUtilities.Requests.Tarefa;
public class CriarTarefaRequestBuilder
{
    public static CriarTarefaRequest Build()
    {
        return new Faker<CriarTarefaRequest>()
        .RuleFor(t => t.Titulo, f => f.Lorem.Sentence(10))
        .RuleFor(t => t.Descricao, f => "olá")
        .RuleFor(t => t.UsuarioId, f => UsuarioBuilder.Build().Id)
        .RuleFor(t => t.Status, _ => "Pendente")
        .Generate();
    }
}
