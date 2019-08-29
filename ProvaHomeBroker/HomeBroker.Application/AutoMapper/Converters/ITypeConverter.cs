using AutoMapper;

namespace HomeBroker.Application.AutoMapper.Converters
{
    public interface ITypeConverter<in TSource, TDestination>
    {
        TDestination Convert(TSource source, TDestination destination, ResolutionContext context);
    }
}
