namespace Cqrs
{
    using System.Threading.Tasks;

    /// <summary>
    /// Base interface for command handlers
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        /// <summary>
        /// Executes a command handler.
        /// </summary>
        /// <param name="command">The command to be used</param>
        Task<CommandResult> Execute(TCommand command);
    }

    /// <summary>
    /// Base interface for command handlers
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public interface ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
        where TResult : new()
    {
        /// <summary>
        /// Executes a command handler.
        /// </summary>
        /// <param name="command">The command to be used</param>
        Task<CommandResult<TResult>> Execute(TCommand command);
    }
}