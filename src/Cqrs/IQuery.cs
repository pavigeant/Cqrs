namespace Cqrs
{
    /// <summary>
    /// Marker interface to mark a query
    /// </summary>
    public interface IQuery<TResult>
        where TResult : IQueryResult, new()
    {
    }
}