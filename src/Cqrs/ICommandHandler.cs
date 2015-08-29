using System.Threading.Tasks;

namespace Cqrs
{
    /// <summary>
    /// Base interface for command handlers
    /// </summary>
    public interface ICommandHandler<in TCommand>
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
    public interface ICommandHandler<in TCommand, TResult>
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