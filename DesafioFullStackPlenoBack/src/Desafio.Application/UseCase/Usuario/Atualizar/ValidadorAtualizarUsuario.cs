using Desafio.Communication.Requests.Usuario;
using Desafio.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.UseCase.Usuario.Atualizar;
public class ValidadorAtualizarUsuario : AbstractValidator<AtualizarUsuarioRequest>
{
    public ValidadorAtualizarUsuario()
    {
        RuleFor(user => user.Nome).NotEmpty().WithMessage(ResourceErrorMessages.NOME_VAZIO);
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.EMAIL_INVALIDO)
            .EmailAddress()
            .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage(ResourceErrorMessages.EMAIL_INVALIDO);
    }
}
