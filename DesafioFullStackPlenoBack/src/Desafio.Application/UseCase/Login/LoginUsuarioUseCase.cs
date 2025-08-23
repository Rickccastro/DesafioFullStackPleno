using AutoMapper;
using Desafio.Application.Security;
using Desafio.Communication.Requests.Login;
using Desafio.Communication.Responses.Login;
using Desafio.Communication.Responses.Usuario;
using Desafio.Domain.Repositories;
using Desafio.Domain.Repositories.Especificas;
using Desafio.Exceptions.ExceptionBase;

namespace Desafio.Application.UseCase.Login;
public class LoginUsuarioUseCase : ILoginUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public LoginUsuarioUseCase(IUsuarioRepository usuarioRepository, IAccessTokenGenerator accessTokenGenerator, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<LoginUsuarioResponse> LoginUsuario(LoginUsuarioRequest request)
    {
        var usuario = await _usuarioRepository.ObterPorPropriedadeAsync(u=> u.Email == request.Email && u.Senha == request.Senha);

        if (usuario == null)
            throw new InvalidLoginException();

        var loginResponse = _mapper.Map<LoginUsuarioResponse>(usuario);

        loginResponse.Token = _accessTokenGenerator.Generate(usuario);

        return loginResponse;
    }
}
