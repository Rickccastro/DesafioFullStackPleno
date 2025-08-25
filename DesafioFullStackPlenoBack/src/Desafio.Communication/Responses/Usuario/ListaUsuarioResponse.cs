namespace Desafio.Communication.Responses.Usuario;
public class ListaUsuarioResponse
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Perfil { get; set; } = null!;
}
