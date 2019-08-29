using System;
using System.Collections.Generic;
using HomeBroker.Domain.Core.Notifications;
using HomeBroker.Domain.Interfaces.Repositories;
using HomeBroker.Domain.Interfaces.Services;
using HomeBroker.Domain.Model;

namespace HomeBroker.Domain.Services
{
    public class CotacaoAcaoService : ICotacaoAcaoService
    {
        #region Propriedades
        private readonly ICotacaoAcaoRepository _cotacaoAcaoRepository;
        private readonly NotificationContext _notificationContext;
        #endregion

        #region Construtores
        public CotacaoAcaoService(ICotacaoAcaoRepository cotacaoAcaoRepository, NotificationContext notificationContext)
        {
            _cotacaoAcaoRepository = cotacaoAcaoRepository;
            _notificationContext = notificationContext;
        }
        #endregion

        #region Metodos que consultam cotacoes
        public IEnumerable<CotacaoAcao> GetAll()
        {
            return _cotacaoAcaoRepository.GetAll();
        }

        public CotacaoAcao GetById(int id)
        {
            return _cotacaoAcaoRepository.GetById(id);
        }
        #endregion

        #region Metodos que alteram o estado de uma cotacao
        public void Add(CotacaoAcao obj)
        {
            if (obj.Invalid) {
                _notificationContext.AddNotifications(obj.ValidationResult);
            }

            if (_cotacaoAcaoRepository.GetByAcaoDataCotacao(obj.CodigoAcao, obj.DataCotacao) != null) {
                _notificationContext.AddNotification("Data da Cotacao", "já existe uma cotação cadastrada para a data informada!!!");
            }

            if(!_notificationContext.HasNotifications)
                _cotacaoAcaoRepository.Add(obj);
        }
        public void Update(CotacaoAcao obj)
        {
            if (obj.Invalid)
                _notificationContext.AddNotifications(obj.ValidationResult);

            if (_cotacaoAcaoRepository.GetByAcaoDataCotacao(obj.CodigoAcao, obj.DataCotacao) != null)
                _notificationContext.AddNotification("Data da Cotacao", "já existe uma cotação cadastrada para a data informada!!!");

            if (!_notificationContext.HasNotifications)
                _cotacaoAcaoRepository.Update(obj);
        }

        public void Remove(int id)
        {
            _cotacaoAcaoRepository.Remove(id);
        }
        #endregion

        #region Outros metodos
        public void Dispose()
        {
            _cotacaoAcaoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
