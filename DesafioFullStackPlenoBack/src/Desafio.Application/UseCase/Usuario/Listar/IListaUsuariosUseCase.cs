using Desafio.Communication.Responses.Usuario;

namespace Desafio.Application.UseCase.Usuario.Listar;
public interface IListaUsuariosUseCase
{
    Task<List<ListaUsuarioResponse>> ListarUsuarios();

}
