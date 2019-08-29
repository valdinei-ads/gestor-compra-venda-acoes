using AutoMapper;
using HomeBroker.Application.AutoMapper.Converters;
using HomeBroker.Application.ViewModels;
using HomeBroker.Domain.Enums;
using HomeBroker.Domain.Model;

namespace HomeBroker.Application.AutoMapper.Profiles
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<CotacaoAcaoViewModel, CotacaoAcao>();
            CreateMap<OrdemViewModel, Ordem>();
        }
    }
}
