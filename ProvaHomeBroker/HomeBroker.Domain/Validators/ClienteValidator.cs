using FluentValidation;
using HomeBroker.Domain.Enums;
using HomeBroker.Domain.Model;
using System.Text.RegularExpressions;

namespace HomeBroker.Domain.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("O nome do cliente é obrigatório!!!");

            RuleFor(c => c.DataNascimento).NotNull().NotEmpty().WithMessage("A data de nascimento do cliente é obrigatória!!!");

            RuleFor(c => c).Must(ValidarTipoPessoa).WithMessage("O tipo de pessoa é obrigatório!!!");

            RuleFor(c => c).Must(ValidarQuantidadeDigitosCPF).WithMessage(c => $"CPF Inválido, o  cpf: {c.CpfCnpj} informado só apresenta {c.CpfCnpj.Length} digitos!!!");

            RuleFor(c => c).Must(ValidarQuantidadeDigitosCPF).WithMessage(c => $"CNPJ Inválido, o  CNPJ: {c.CpfCnpj} informado só apresenta {c.CpfCnpj.Length} digitos!!!");
        }

        public static bool ValidarQuantidadeDigitosCPF(Cliente cliente) {

            bool isValid = true;

            // Se o CPF foi preenchido e o tipo de pessoa for fisica valida a quantidade de digitos do CPF
            if (!string.IsNullOrWhiteSpace(cliente.CpfCnpj) &&  TipoPessoa.F.Equals(cliente.TipoPessoa))
                isValid = cliente.CpfCnpj.ToString().Replace("-", "").Replace(".", "").Length == 11;

            return isValid;
        }
       
        public static bool ValidarQuantidadeDigitosCNPJ(Cliente cliente)
        {
            bool isValid = true;
            
            // se o CNPJ foi preenchido e o tipo de pessoa for juridica valida a quantidade de digitos informados para cnpj
            if (!string.IsNullOrWhiteSpace(cliente.CpfCnpj) && TipoPessoa.J.Equals(cliente.TipoPessoa))
                isValid = cliente.CpfCnpj.ToString().Replace("-", "").Replace(".", "").Length == 14;

            return isValid;
        }

        public static bool ValidarTipoPessoa(Cliente cliente) {

            bool isValid = true;
            if (cliente.TipoPessoa != TipoPessoa.F && cliente.TipoPessoa != TipoPessoa.J)
                isValid = false;

            return isValid;
        }

    }
}
