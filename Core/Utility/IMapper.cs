namespace Core.Utility
{
    /// <summary>
    ///     Maps the object to a specified type
    /// </summary>
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}