using System;
using System.Collections.Generic;

namespace HomeBroker.Application.Interfaces
{
    public interface IAppService<TViewModel> : IDisposable where TViewModel : class
    {
        TViewModel GetById(int id);
        IEnumerable<TViewModel> GetAll();

        int Add(TViewModel obj);
        int Update(TViewModel obj);
        int Remove(int id);
    }
}
