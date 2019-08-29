using HomeBroker.Domain.Interfaces.Repositories;
using HomeBroker.Domain.Model;
using HomeBroker.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HomeBroker.Infrastructure.Data.Repositories
{
    public class OrdemRepository : Repository<Ordem>, IOrdemRepository
    {
        #region Construtores
        public OrdemRepository(DataContext db) : base(db) {}
        #endregion

        #region Metodos que consultam ordens
        public IEnumerable<Ordem> GetAll() => 
            _dbSet.Include("Cliente");

        public Ordem GetById(int id) =>
            _dbSet.Include("Cliente").FirstOrDefault(c=> c.IdOrdem == id);
        #endregion
    }
}
