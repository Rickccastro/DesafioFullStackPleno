using AutoMapper;
using Desafio.Communication.Requests.Usuario;
using Desafio.Communication.Responses.Usuario;
using Desafio.Domain.Repositories;
using Desafio.Domain.Repositories.Especificas;

namespace Desafio.Application.UseCase.Usuario.Cria;
public class CriarUsuarioUseCase : ICriarUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public CriarUsuarioUseCase(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UsuarioResponse> CriarUsuario(UsuarioRequest request)
    {
        var userId = Guid.NewGuid();

        var usuario = _mapper.Map<Domain.Entities.Usuario>(request);


        await _usuarioRepository.AdicionarAsync(usuario);
        await _unitOfWork.Commit();

        return _mapper.Map<UsuarioResponse>(usuario);
    }
}
