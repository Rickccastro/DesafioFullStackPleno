using Desafio.Domain.Enums;

namespace Desafio.Domain.Entities;

internal class Usuario
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public Guid UserIdentifier { get; set; }
    public string Perfil { get; set; } = Perfis.ADMINISTRADOR;
}
