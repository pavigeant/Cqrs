namespace Cqrs
{
    using Configuration;
    using System;
    using System.Threading.Tasks;

    internal class QueryDispatcher: IQueryDispatcher
    {
        private readonly IContainer _container;

        public QueryDispatcher(IContainer container)
        {            
            _container = container;
        }

        public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult, new()
        {
            var handler = _container.GetInstance<IQueryHandler<TQuery, TResult>>();
            if(handler == null)
                throw Exceptions.QueryNotHandled<TQuery, TResult>();

            return await handler.Retrieve(query);
        }
    }
}