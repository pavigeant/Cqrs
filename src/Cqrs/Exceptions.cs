namespace Cqrs
{
    using System;

    internal static class Exceptions
    {
        internal static HandlerNotImplementedException CommandNotHandled<TCommand>()
            where TCommand : ICommand
        {
            return new HandlerNotImplementedException($"No command handler was found for command {nameof(TCommand)}.");
        }

        internal static HandlerNotImplementedException QueryNotHandled<TQuery, TResult>()
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult, new()
        {
            return new HandlerNotImplementedException($"No query handler was found for query {nameof(TQuery)}.");
        }
    }
}
