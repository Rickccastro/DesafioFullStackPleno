using Desafio.Communication.Requests.Login;
using Desafio.Communication.Responses.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.UseCase.Login;
public interface ILoginUsuarioUseCase
{
    Task<LoginUsuarioResponse> LoginUsuario(LoginUsuarioRequest request);
}
