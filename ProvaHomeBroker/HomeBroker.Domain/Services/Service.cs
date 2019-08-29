using HomeBroker.Domain.Core.Repositories;
using HomeBroker.Domain.Core.Services;
using System;
using System.Collections.Generic;

namespace HomeBroker.Domain.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        #region Properties
        private readonly IRepository<TEntity> _repository;
        #endregion

        #region Constructors
        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        #endregion

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);   
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
