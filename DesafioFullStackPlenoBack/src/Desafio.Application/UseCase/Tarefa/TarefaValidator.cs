using Desafio.Communication.Requests.Tarefa;
using Desafio.Domain.Enums;
using Desafio.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.UseCase.Tarefa;
public class TarefaValidator : AbstractValidator<TarefaRequest>
{
    public TarefaValidator()
    {
        RuleFor(expense => expense.Titulo).NotEmpty().WithMessage(ResourceErrorMessages.TITULO_OBRIGATORIO);
        RuleFor(expense => expense.Descricao).MaximumLength(500).WithMessage(ResourceErrorMessages.TAREFA_DESCRICAO_LIMITE);
        RuleFor(expense => expense.Status)
            .Must(s => Enum.TryParse<StatusTarefa>(s, true, out _))
            .WithMessage(ResourceErrorMessages.STATUS_TAREFA_INVALIDA);
    }
}
