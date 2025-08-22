using Bogus;
using Desafio.Domain.Entities;
using Desafio.Domain.Enums;

namespace CommonTestsUtilities.Entities;
public static class TarefaBuilder
{
    public static Tarefa Build(Usuario usuario,StatusTarefa status = StatusTarefa.Pendente)
    {
        return new Faker<Tarefa>()
        .RuleFor(t => t.Id, _ => Guid.NewGuid())
        .RuleFor(t => t.Titulo, f => f.Lorem.Sentence(10)) 
        .RuleFor(t => t.Descricao, f => f.Lorem.Paragraph(30))
        .RuleFor(t => t.DataCriacao, f => DateTime.UtcNow)
        .RuleFor(t => t.UsuarioId, _ => usuario.Id)
        .RuleFor(t => t.Status, _ => status)
        .Generate();
    }
}
