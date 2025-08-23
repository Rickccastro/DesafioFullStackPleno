namespace Desafio.Communication.Responses.Tarefa;
public class TarefaResponse
{
    public Guid Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descricao { get; set; }

    public string Status { get; set; } = null!;

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public Guid UsuarioId { get; set; }
}
