namespace Desafio.Communication.Requests.Tarefa;
public class DeletarTarefaRequest
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = null!;
}
