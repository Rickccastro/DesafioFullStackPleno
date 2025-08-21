using Desafio.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Desafio.Domain.Entities;

public partial class Tarefa
{
    public Guid Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descricao { get; set; }

    public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;

    public DateTime DataCriacao { get; set; }

    public Guid UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
