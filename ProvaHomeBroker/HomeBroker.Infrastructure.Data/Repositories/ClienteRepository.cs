using HomeBroker.Domain.Interfaces.Repositories;
using HomeBroker.Domain.Model;
using HomeBroker.Infrastructure.Data.Context;

namespace HomeBroker.Infrastructure.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DataContext db) : base(db)
        {
        }
    }
}
