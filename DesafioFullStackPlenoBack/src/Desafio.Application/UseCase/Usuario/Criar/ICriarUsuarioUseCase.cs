using Desafio.Communication.Requests.Usuario;
using Desafio.Communication.Responses.Usuario;

namespace Desafio.Application.UseCase.Usuario.Cria;
public interface ICriarUsuarioUseCase
{
    Task<UsuarioResponse> CriarUsuario(CriarUsuarioRequest request);
}
