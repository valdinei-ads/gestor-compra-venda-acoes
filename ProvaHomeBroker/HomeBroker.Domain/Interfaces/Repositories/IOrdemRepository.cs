using HomeBroker.Domain.Core.Repositories;
using HomeBroker.Domain.Model;
using System.Collections.Generic;

namespace HomeBroker.Domain.Interfaces.Repositories
{
    public interface IOrdemRepository : IRepository<Ordem>
    {
        IEnumerable<Ordem> GetAll();
        Ordem GetById(int id);
    }
}
