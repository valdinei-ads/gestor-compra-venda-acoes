using FluentValidation;
using HomeBroker.Domain.Enums;
using HomeBroker.Domain.Model;
using System;

namespace HomeBroker.Domain.Validators
{
    public class OrdemValidator : AbstractValidator<Ordem>
    {
        public OrdemValidator()
        {
            RuleFor(c => c)
                .Must(ValidarTipoOrdem).WithMessage("O tipo de ordem é obrigatório!!!");

            RuleFor(c => c.CodigoAcao)
               .NotEmpty().WithMessage("O código da ação é obrigatório!!!")
               .MinimumLength(5).WithMessage("O código da ação deve ter entre 5 e 10 cadaracters!!!")
               .MaximumLength(10).WithMessage("O código da ação deve ter entre 5 e 10 cadaracters!!!");

            RuleFor(c => c.DataOrdem)
                .NotNull().WithMessage("A data da ordem é obrigatória!!!")
                .NotEqual(DateTime.MinValue).WithMessage("A data da cotação é Inválida!!!");

            RuleFor(c => c.IdCliente)
                .NotEqual(0).WithMessage("O cliente é obrigatório!!!");

            RuleFor(c => c)
                .Must(ValidarDataCompra).WithMessage("Para ordens de venda a data de compra é obrigatória!!!");

            RuleFor(c => c.QuantidadeAcoes)
                .LessThan(1).WithMessage("é obrigatório que a ordem tenha pelo menos 1 ação!!!");
        }

        public static bool ValidarDataCompra(Ordem ordem) {
            return TipoOrdem.V.Equals(ordem.TipoOrdem) && (ordem.DataCompra == null || DateTime.MinValue.Equals(ordem.DataCompra));
        }

        public static bool ValidarTipoOrdem(Ordem ordem) {
            return TipoOrdem.C.Equals(ordem.TipoOrdem) || TipoOrdem.V.Equals(ordem.TipoOrdem);
        }
    }
}
