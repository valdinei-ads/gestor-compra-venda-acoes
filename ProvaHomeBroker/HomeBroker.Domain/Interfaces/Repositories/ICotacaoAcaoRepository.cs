using System;
using HomeBroker.Domain.Core.Repositories;
using HomeBroker.Domain.Model;

namespace HomeBroker.Domain.Interfaces.Repositories
{
    public interface ICotacaoAcaoRepository : IRepository<CotacaoAcao>
    {
        CotacaoAcao GetByAcaoDataCotacao(string codigoAcao, DateTime? dataCotacao);
    }
}
