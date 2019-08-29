using System;
using System.Collections.Generic;
using HomeBroker.Application.ViewModels;

namespace HomeBroker.Application.Interfaces
{
    public interface ICotacaoAcaoAppService : IDisposable
    {
        IEnumerable<CotacaoAcaoViewModel> GetAll();
        CotacaoAcaoViewModel GetById(int id);

        void Add(CotacaoAcaoViewModel cotacao);
        void Update(CotacaoAcaoViewModel cotacao);
        void Remove(int id);
    }
}
