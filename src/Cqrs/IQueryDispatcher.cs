using System.Threading.Tasks;

namespace Cqrs
{
    /// <summary>
    /// Passed around to all allow dispatching a query and to be mocked by unit tests
    /// </summary>
    public interface IQueryDispatcher
    {   
        /// <summary>
        /// Dispatches a query and retrieves a query result
        /// </summary>
        /// <typeparam name="TQuery">Query to execute type</typeparam>
        /// <typeparam name="TResult">Query Result to get back type</typeparam>
        /// <param name="query">Query to execute</param>
        /// <returns>Query Result to get back</returns>
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult, new();
    }
}
