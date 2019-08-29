using HomeBroker.Domain.Core.Model;
using HomeBroker.Domain.Validators;
using System;

namespace HomeBroker.Domain.Model
{
    public class CotacaoAcao : Entity
    {
        public int IdCotacaoAcao { get; private set; }
        public string CodigoAcao { get; private set; }
        public DateTime DataCotacao { get; private set; }
        public decimal ValorCotacao { get; private set; }

        public CotacaoAcao(string codigoAcao, DateTime dataCotacao, decimal valorCotacao)
        {
            this.CodigoAcao = codigoAcao;
            this.DataCotacao = dataCotacao;
            this.ValorCotacao = valorCotacao;

            Validate(this, new CotacaoAcaoValidator());
        }

    }
}
