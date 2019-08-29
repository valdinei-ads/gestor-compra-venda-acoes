using HomeBroker.Domain.Core.Model;
using HomeBroker.Domain.Enums;
using HomeBroker.Domain.Validators;
using System;

namespace HomeBroker.Domain.Model
{
    public class Ordem : Entity
    {
        public int IdOrdem { get; private set; }
        public TipoOrdem TipoOrdem { get; private set; }
        public DateTime DataOrdem { get; private set; }
        public string CodigoAcao { get; private set; }
        public int QuantidadeAcoes { get; private set; }
        public DateTime? DataCompra { get; private set; }

        #region ValorOrdem
        private decimal valorOrdem;
        public decimal ValorOrdem
        {
            get { return this.valorOrdem; }
            set { this.valorOrdem = value; }
        }
        #endregion

        #region TaxaCorretagem
        private decimal taxaCorretagem;
        public decimal TaxaCorretagem
        {
            get { return this.taxaCorretagem; }
            set { this.taxaCorretagem = value; }
        }
        #endregion

        #region IR
        public decimal ir { get; private set; }
        public decimal IR
        {
            get { return this.ir; }
            set { this.ir = value; }
        }
        #endregion

        #region Cliente
        public int IdCliente { get; private set; }
        private Cliente cliente;
        public virtual Cliente Cliente
        {
            get { return this.cliente; }
            set { this.cliente = value; }
        }
        #endregion

        public Ordem(int idOrdem, TipoOrdem tipoOrdem, DateTime dataOrdem, string codigoAcao, int quantidadeAcoes,
            DateTime? dataCompra, decimal valorOrdem, decimal taxaCorretagem, decimal iR, int idCliente)
        {
            this.IdOrdem = idOrdem;
            this.TipoOrdem = tipoOrdem;
            this.DataOrdem = dataOrdem;
            this.CodigoAcao = codigoAcao;
            this.QuantidadeAcoes = quantidadeAcoes;
            this.DataCompra = dataCompra;
            this.ValorOrdem = valorOrdem;
            this.TaxaCorretagem = taxaCorretagem;
            this.IR = iR;
            this.IdCliente = idCliente;
            

            Validate(this, new OrdemValidator());
        }
    }
}
