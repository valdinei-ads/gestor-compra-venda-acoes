using HomeBroker.Domain.Core.Model;
using HomeBroker.Domain.Enums;
using HomeBroker.Domain.Validators;
using System;
using System.Collections.Generic;

namespace HomeBroker.Domain.Model
{
    public class Cliente : Entity
    {
        public int IdCliente { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public TipoPessoa TipoPessoa { get; private set; }
        public string CpfCnpj { get; private set; }
        public IEnumerable<Ordem> Ordens { get; private set; }

        public Cliente(string nome, DateTime dataNascimento, TipoPessoa tipoPessoa, string cpfCnpj)
        {
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.TipoPessoa = tipoPessoa;
            this.CpfCnpj = cpfCnpj;

            Validate(this, new ClienteValidator());
        }
    }
}
