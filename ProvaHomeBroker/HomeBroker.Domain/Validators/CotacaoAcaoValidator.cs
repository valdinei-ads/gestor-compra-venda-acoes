using FluentValidation;
using HomeBroker.Domain.Model;
using System;

namespace HomeBroker.Domain.Validators
{
    public class CotacaoAcaoValidator : AbstractValidator<CotacaoAcao>
    {
        public CotacaoAcaoValidator()
        {
            RuleFor(c => c.CodigoAcao)
                .NotEmpty().WithMessage("O código da ação é obrigatório!!!")
                .MinimumLength(5).WithMessage("O código da ação deve ter entre 5 e 10 cadaracters!!!")
                .MaximumLength(10).WithMessage("O código da ação deve ter entre 5 e 10 cadaracters!!!");

            RuleFor(c => c.DataCotacao)
                .NotNull().WithMessage("A data da cotação é Inválida!!!")
                .NotEqual(DateTime.MinValue).WithMessage("A data da cotação é Inválida!!!");

            RuleFor(c => c.DataCotacao)
                .LessThan(DateTime.Now).WithMessage("A data da cotação náo pode ser maior que a data atual!!!");

            RuleFor(c => c.ValorCotacao)
                .NotNull().WithMessage("o valor da cotação é obrigatório!!!");
                
        }
    }
}
