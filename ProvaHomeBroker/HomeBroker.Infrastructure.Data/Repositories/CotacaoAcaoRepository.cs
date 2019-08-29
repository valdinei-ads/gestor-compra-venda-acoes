using HomeBroker.Domain.Interfaces.Repositories;
using HomeBroker.Domain.Model;
using HomeBroker.Infrastructure.Data.Context;
using System;
using System.Linq;

namespace HomeBroker.Infrastructure.Data.Repositories
{
    public class CotacaoAcaoRepository : Repository<CotacaoAcao>, ICotacaoAcaoRepository
    {
        public CotacaoAcaoRepository(DataContext db) : base(db) {}

        public CotacaoAcao GetByAcaoDataCotacao(string codigoAcao, DateTime? dataCotacao) =>
            _dbSet.FirstOrDefault(c => c.CodigoAcao == codigoAcao && c.DataCotacao == dataCotacao);
        
        public CotacaoAcao GetByCodigo(string codigo)
        {
            return _dbSet.FirstOrDefault(c => c.CodigoAcao == codigo);    
        }

        
    }
}
