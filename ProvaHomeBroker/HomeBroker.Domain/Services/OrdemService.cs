using System;
using System.Collections.Generic;
using HomeBroker.Domain.Core.Notifications;
using HomeBroker.Domain.Enums;
using HomeBroker.Domain.Interfaces.Repositories;
using HomeBroker.Domain.Interfaces.Services;
using HomeBroker.Domain.Model;

namespace HomeBroker.Domain.Services
{
    public class OrdemService : IOrdemService
    {
        #region Propriedades
        private readonly IOrdemRepository _ordemRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ICotacaoAcaoRepository _cotacaoRepository;
        private readonly NotificationContext _notificationContext;
        #endregion

        #region Construtores
        public OrdemService(
            IOrdemRepository ordemRepository,
            IClienteRepository clienteRepository,
            ICotacaoAcaoRepository cotacaoRepository,
            NotificationContext notificationContext)
        {
            _ordemRepository = ordemRepository;
            _clienteRepository = clienteRepository;
            _cotacaoRepository = cotacaoRepository;
            _notificationContext = notificationContext;
        }
        #endregion

        #region Metodos que consultam ordens
        public IEnumerable<Ordem> GetAll() =>
            _ordemRepository.GetAll();

        public Ordem GetById(int id) =>
            _ordemRepository.GetById(id);
        #endregion

        #region Medotos que alteram o estado de uma ordem
        public void Add(Ordem obj)
        {
            obj.Cliente = _clienteRepository.GetById(obj.IdCliente);
            var cotacaoDataOrdem = _cotacaoRepository.GetByAcaoDataCotacao(obj.CodigoAcao, obj.DataOrdem);
            var cotacaoDataCompra = _cotacaoRepository.GetByAcaoDataCotacao(obj.CodigoAcao, obj.DataCompra);

            if (cotacaoDataOrdem == null)
                _notificationContext.AddNotification("Data de Ordem", "Náo existe cotacao para a data de ordem informada!!!");

            if (TipoOrdem.V.Equals(obj.TipoOrdem) && cotacaoDataCompra == null)
                _notificationContext.AddNotification("Data de Compra", "Náo existe cotacao para a data de compra informada!!!");

            if (!_notificationContext.HasNotifications)
            {
                obj.ValorOrdem = obj.QuantidadeAcoes * cotacaoDataOrdem.ValorCotacao;

                // Calcula Taxa de corretagem
                switch (obj.TipoOrdem)
                {
                    case TipoOrdem.C:

                        // sendo uma ordem de compra nao tem imposto de renda
                        obj.IR = 0;

                        switch (obj.Cliente.TipoPessoa)
                        {
                            case TipoPessoa.F:

                                if (obj.ValorOrdem >= 2000000)
                                    obj.TaxaCorretagem = obj.ValorOrdem * (decimal)0.75;
                                else
                                    obj.TaxaCorretagem = 0;

                                break;
                            case TipoPessoa.J:

                                if (obj.ValorOrdem >= 2000000)
                                    obj.TaxaCorretagem = obj.ValorOrdem * (decimal)0.45;
                                else
                                    obj.TaxaCorretagem = obj.ValorOrdem * (decimal)0.25;

                                break;
                        }
                        break;
                    case TipoOrdem.V:

                        // sendo uma ordem de venda calcula o imposto de renda
                        var variacao = cotacaoDataOrdem.ValorCotacao - cotacaoDataCompra.ValorCotacao;
                        if (variacao > 0)
                            obj.IR = (obj.QuantidadeAcoes * variacao) * (decimal)0.15;

                        switch (obj.Cliente.TipoPessoa)
                        {
                            case TipoPessoa.F:
                                obj.TaxaCorretagem = obj.ValorOrdem * (decimal)0.70;
                                break;
                            case TipoPessoa.J:
                                obj.TaxaCorretagem = obj.ValorOrdem * (decimal)0.60;
                                break;
                        }
                        break;
                }
                _ordemRepository.Add(obj);
            }

        }

        // Para ordem náo é necessario implementar a exclusao
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        // Para ordem náo é necessario implementar a alteracao
        public void Update(Ordem obj)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Outros metodos
        public void Dispose()
        {
            _ordemRepository.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
