using AutoMapper;
using HomeBroker.Application.ViewModels;
using HomeBroker.Domain.Enums;
using HomeBroker.Domain.Model;
using System;
using System.Collections;

namespace HomeBroker.Application.AutoMapper.Profiles
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();

            CreateMap<CotacaoAcao, CotacaoAcaoViewModel>();
            CreateMap<Ordem, OrdemViewModel>();
        }


        //public static TipoPessoa MapTipoPessoa(string tipoPessoa)
        //{
        //    return EnumHelper<TipoPessoa>.Parse(tipoPessoa);
        //}

    }
}
