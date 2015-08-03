namespace Cqrs
{
    using System.Threading.Tasks;

    /// <summary>
    /// Base interface for query handlers
    /// </summary>
    /// <typeparam name="TQuery">Query type</typeparam>
    /// <typeparam name="TResult">Query Result type</typeparam>
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : IQueryResult, new()
    {
        /// <summary>
        /// Retrieve a query result from a query
        /// </summary>
        /// <param name="query">Query</param>
        /// <returns>Retrieve Query Result</returns>
        Task<TResult> Retrieve(TQuery query);
    }
}
