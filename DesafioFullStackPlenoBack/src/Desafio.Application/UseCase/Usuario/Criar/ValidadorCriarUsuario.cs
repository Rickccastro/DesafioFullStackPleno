using Desafio.Communication.Requests.Usuario;
using Desafio.Exceptions;
using FluentValidation;


namespace Desafio.Application.UseCase.Usuario.Criar;
public class ValidadorCriarUsuario : AbstractValidator<CriarUsuarioRequest>
{
    public ValidadorCriarUsuario()
    {
        RuleFor(user => user.Nome).NotEmpty().WithMessage(ResourceErrorMessages.NOME_VAZIO);
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.EMAIL_VAZIO)
            .EmailAddress()
            .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage(ResourceErrorMessages.EMAIL_INVALIDO);
    }
}