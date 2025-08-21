using AutoMapper;
using Desafio.Communication.Requests.Usuario;
using Desafio.Communication.Responses.Usuario;
using Desafio.Domain.Repositories;
using Desafio.Domain.Repositories.Especificas;

namespace Desafio.Application.UseCase.Usuario.Atualizar;
public class AtualizarUsuarioUseCase : IAtualizarUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public AtualizarUsuarioUseCase(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UsuarioResponse> AtualizarUsuario(AtualizarUsuarioRequest request)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(request.Id);

        if (usuario == null)
            throw new Exception("Usuário não encontrado.");

        _mapper.Map(request, usuario);

        await _usuarioRepository.AtualizarAsync(usuario);
        await _unitOfWork.Commit();

        return _mapper.Map<UsuarioResponse>(usuario);
    }
}
