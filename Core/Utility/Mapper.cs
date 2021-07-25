using Mapster;

namespace Core.Utility
{
    public class Mapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return source.Adapt<TDestination>();
        }
    }
}