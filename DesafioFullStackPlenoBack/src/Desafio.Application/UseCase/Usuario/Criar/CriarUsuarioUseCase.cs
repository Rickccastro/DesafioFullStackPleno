using AutoMapper;
using Desafio.Application.UseCase.Usuario.Criar;
using Desafio.Communication.Requests.Usuario;
using Desafio.Communication.Responses.Usuario;
using Desafio.Domain.Repositories;
using Desafio.Domain.Repositories.Especificas;
using Desafio.Exceptions;
using Desafio.Exceptions.ExceptionBase;
using FluentValidation.Results;

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

    public async Task<UsuarioResponse> CriarUsuario(CriarUsuarioRequest request)
    {
        await Validate(request);

        var usuario = _mapper.Map<Domain.Entities.Usuario>(request);
        usuario.Id = Guid.NewGuid();

        await _usuarioRepository.AdicionarAsync(usuario);
        await _unitOfWork.Commit();

        return _mapper.Map<UsuarioResponse>(usuario);
    }

    private async Task Validate(CriarUsuarioRequest request)
    {
        var result = new ValidadorCriarUsuario().Validate(request);

        var emailExist = await _usuarioRepository.ObterPorPropriedadeAsync(e => e.Email ==request.Email);
     
        if (emailExist !=null)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_JA_CADASTRADO));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
