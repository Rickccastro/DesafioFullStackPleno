namespace WebtApi.test.Resources;
public class UsuarioHelper
{
    private readonly Desafio.Domain.Entities.Usuario _usuario;
    private readonly string _token;


    public UsuarioHelper(Desafio.Domain.Entities.Usuario usuario, string token)
    {
        _usuario = usuario;
        _token = token; 
    }

    public Guid GetId() => _usuario.Id;
    public string GetNome() => _usuario.Nome;
    public string GetEmail() => _usuario.Email;
    public string GetSenha() => _usuario.Senha;
    public string GetToken() => _token;
}
