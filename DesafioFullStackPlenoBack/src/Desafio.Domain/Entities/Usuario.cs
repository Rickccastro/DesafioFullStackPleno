using Desafio.Domain.Enums;

namespace Desafio.Domain.Entities;

public partial class Usuario
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public Perfis Perfil { get; set; } = Perfis.Usuario;

    public virtual ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
}
