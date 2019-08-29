using AutoMapper;
using HomeBroker.Application.Interfaces;
using HomeBroker.Application.ViewModels;
using HomeBroker.Domain.Interfaces.Services;
using HomeBroker.Domain.Model;
using System;
using System.Collections.Generic;

namespace HomeBroker.Application.Services
{
    public class OrdemAppService : IOrdemAppService
    {

        #region Propriedades
        private readonly IOrdemService _ordemService;
        private readonly IMapper _mapper;
        #endregion

        #region Construtores
        public OrdemAppService(IOrdemService ordemService,  IMapper mapper)
        {
            _ordemService = ordemService;
            _mapper = mapper;
        }
        #endregion

        #region Metodos que consultam ordens
        public IEnumerable<OrdemViewModel> GetAll() => 
            _mapper.Map<IEnumerable<OrdemViewModel>>(_ordemService.GetAll());

        public OrdemViewModel GetById(int id) => 
            _mapper.Map<OrdemViewModel>(_ordemService.GetById(id));
        #endregion

        #region Metodos que alteram o estado de uma ordem
        public void Add(OrdemViewModel ordem) {
            var novaOrdem = _mapper.Map<Ordem>(ordem);
            _ordemService.Add(novaOrdem);
        }
        #endregion

        #region Outros metodos
        public void Dispose()
        {
            _ordemService.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
