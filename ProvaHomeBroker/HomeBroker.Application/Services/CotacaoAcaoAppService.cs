using AutoMapper;
using HomeBroker.Application.Interfaces;
using HomeBroker.Application.ViewModels;
using HomeBroker.Domain.Interfaces.Services;
using HomeBroker.Domain.Model;
using System;
using System.Collections.Generic;

namespace HomeBroker.Application.Services
{
    public class CotacaoAcaoAppService : ICotacaoAcaoAppService
    {
        #region propriedades
        private readonly ICotacaoAcaoService _cotacaoAcaoService;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public CotacaoAcaoAppService(ICotacaoAcaoService cotacaoAcaoService, IMapper mapper)
        {
            _cotacaoAcaoService = cotacaoAcaoService;
            _mapper = mapper;
        }
        #endregion

        #region Metodos que consultam cotacoes
        public IEnumerable<CotacaoAcaoViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<CotacaoAcaoViewModel>>(_cotacaoAcaoService.GetAll());
        }

        public CotacaoAcaoViewModel GetById(int id)
        {
            return _mapper.Map<CotacaoAcaoViewModel>(_cotacaoAcaoService.GetById(id));
        }
        #endregion

        #region Metodos que alteram o estado de um objeto
        public void Add(CotacaoAcaoViewModel cotacaoAcaoVM)
        {
            var cotacaoAcao = _mapper.Map<CotacaoAcao>(cotacaoAcaoVM);
            _cotacaoAcaoService.Add(cotacaoAcao);
        }

        public void Update(CotacaoAcaoViewModel cotacaoAcaoVM)
        {
            var cotacaoAcao = _mapper.Map<CotacaoAcao>(cotacaoAcaoVM);
            _cotacaoAcaoService.Update(cotacaoAcao);
        }

        public void Remove(int id)
        {
            _cotacaoAcaoService.Remove(id);
        }
        #endregion

        #region Outros metodos
        public void Dispose()
        {
            _cotacaoAcaoService.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
