using HomeBroker.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace HomeBroker.Application.Interfaces
{
    public interface IOrdemAppService : IDisposable
    {
        IEnumerable<OrdemViewModel> GetAll();
        OrdemViewModel GetById(int id);

        void Add(OrdemViewModel ordem);
    }
}
