namespace Desafio.Communication.Requests.Tarefa;
public class TarefaRequest
{
    public string Titulo { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string Status { get; set; } = null!;
    public Guid UsuarioId { get; set; }
}
