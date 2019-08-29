using AutoMapper;
using HomeBroker.Application.Interfaces;
using HomeBroker.Application.ViewModels;
using HomeBroker.Domain.Interfaces.Services;
using HomeBroker.Domain.Model;
using System;
using System.Collections.Generic;

namespace HomeBroker.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {

        #region Propriedades
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public ClienteAppService(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }
        #endregion

        #region Metodos que consultam clientes
        public IEnumerable<ClienteViewModel> GetAll() =>
            _mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.GetAll());

        public ClienteViewModel GetById(int id) =>
            _mapper.Map<ClienteViewModel>(_clienteService.GetById(id));
        #endregion

        #region Metdos que alteram o estado de um cliente
        public void Add(ClienteViewModel clienteVM)
        {
            var cliente = _mapper.Map<Cliente>(clienteVM);
            _clienteService.Add(cliente);
        }

        public void Update(ClienteViewModel clienteVM)
        {
            var cliente = _mapper.Map<Cliente>(clienteVM);
            _clienteService.Update(cliente);
        }

        public void Remove(int id)
        {
            _clienteService.Remove(id);
        }
        #endregion

        #region Outros metodos
        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
