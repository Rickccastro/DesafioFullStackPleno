using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Communication.Requests.Tarefa;
public class AtualizarTarefaRequest
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public DateTime DataCriacao { get; set; }
    public string Status { get; set; } = null!;
    public Guid UsuarioId { get; set; }
}

