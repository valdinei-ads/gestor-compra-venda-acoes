using HomeBroker.Domain.Core.Repositories;
using HomeBroker.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HomeBroker.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Propriedades
        protected readonly DataContext _db;
        protected readonly DbSet<TEntity> _dbSet;
        #endregion

        #region Construtores
        public Repository(DataContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }
        #endregion

        #region Metodos que consultam um registro
        public IQueryable<TEntity> GetAll() =>
            _dbSet;

        public TEntity GetById(int id) =>
            _dbSet.Find(id);
        #endregion

        #region Metodos que alteram o estado de um registro
        public  void Add(TEntity obj)
        {
            _dbSet.Add(obj);
            _db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _dbSet.Update(obj);
            _db.SaveChanges();
        }
        
        public void Remove(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            _db.SaveChanges();
        }

        public int SaveChanges()
        {
            return SaveChanges();
        }
        #endregion

        #region Outros metodos
        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
