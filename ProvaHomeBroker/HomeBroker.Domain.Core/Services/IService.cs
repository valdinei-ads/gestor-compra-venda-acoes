using System;
using System.Collections.Generic;

namespace HomeBroker.Domain.Core.Services
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(int id);
    }
}
