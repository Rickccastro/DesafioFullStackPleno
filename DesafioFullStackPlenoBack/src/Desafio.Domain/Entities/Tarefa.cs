using System;
using System.Collections.Generic;

namespace Desafio.Domain.Entities;

public partial class Tarefa
{
    public Guid Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descricao { get; set; }

    public string Status { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public Guid UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
