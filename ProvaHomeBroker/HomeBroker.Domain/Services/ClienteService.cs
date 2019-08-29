using System;
using System.Collections.Generic;
using HomeBroker.Domain.Core.Notifications;
using HomeBroker.Domain.Interfaces.Repositories;
using HomeBroker.Domain.Interfaces.Services;
using HomeBroker.Domain.Model;

namespace HomeBroker.Domain.Services
{
    public class ClienteService : IClienteService
    {
        #region Propriedades
        private readonly IClienteRepository _clienteRepository;
        private readonly NotificationContext _notificationContext;
        #endregion

        #region Construtores
        public ClienteService(IClienteRepository clienteRepository, NotificationContext notifications)
        {
            _clienteRepository = clienteRepository;
            _notificationContext = notifications;
        }
        #endregion

        #region Metodos que consultam clientes
        public IEnumerable<Cliente> GetAll() =>
            _clienteRepository.GetAll();

        public Cliente GetById(int id) =>
             _clienteRepository.GetById(id);
        #endregion

        #region Metodos que alteram o estado de um cliente
        public void Add(Cliente obj)
        {
            if (obj.Invalid)
                _notificationContext.AddNotifications(obj.ValidationResult);

            _clienteRepository.Add(obj);
        }

        public void Update(Cliente obj)
        {
            if (obj.Invalid)
                _notificationContext.AddNotifications(obj.ValidationResult);

            _clienteRepository.Update(obj);
        }

        public void Remove(int id)
        {
            _clienteRepository.Remove(id);
        }
        #endregion

        #region Outros metodos
        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
