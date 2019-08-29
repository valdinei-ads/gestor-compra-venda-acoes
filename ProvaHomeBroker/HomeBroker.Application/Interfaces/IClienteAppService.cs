using System;
using System.Collections.Generic;
using HomeBroker.Application.ViewModels;

namespace HomeBroker.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        IEnumerable<ClienteViewModel> GetAll();
        ClienteViewModel GetById(int id);
        void Add(ClienteViewModel cliente);
        void Update(ClienteViewModel cliente);
        void Remove(int id);
    }
}
