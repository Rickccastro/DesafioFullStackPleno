using Desafio.Domain.Entities;
using Desafio.Domain.Enums;

namespace WebtApi.test.Resources;
public class TarefasHelper
{
    public Tarefa _tarefa { get; set; }
    public TarefasHelper(Tarefa tarefa)
    {
        _tarefa = tarefa;
    }

    public Guid GetId() => _tarefa.Id;
    public string GetTitulo() => _tarefa.Titulo;
    public string GetDescricao() => _tarefa.Descricao;
    public DateTime GetDataCriada() => _tarefa.DataCriacao;
    public StatusTarefa GetStatus() => _tarefa.Status;
}
