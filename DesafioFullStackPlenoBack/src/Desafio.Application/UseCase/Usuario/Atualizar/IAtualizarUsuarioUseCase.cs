using Desafio.Communication.Requests.Usuario;
using Desafio.Communication.Responses.Usuario;

namespace Desafio.Application.UseCase.Usuario.Atualizar;
public interface IAtualizarUsuarioUseCase
{
    Task<UsuarioResponse> AtualizarUsuario(AtualizarUsuarioRequest request);
}
