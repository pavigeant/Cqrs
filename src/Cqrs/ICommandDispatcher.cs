namespace Cqrs
{
    using System.Threading.Tasks;
    using Cqrs.Validation;


    /// <summary>
    /// Passed around to all allow dispatching a command and to be mocked by unit tests
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Dispatches a command to its handler
        /// </summary>
        /// <typeparam name="TParameter">Command Type</typeparam>
        /// <param name="command">The command to be passed to the handler</param>
        Task<CommandResult<TResult>> Dispatch<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
            where TResult : new();

        /// <summary>
        /// Dispatches a command to its handler
        /// </summary>
        /// <typeparam name="TParameter">Command Type</typeparam>
        /// <param name="command">The command to be passed to the handler</param>
        Task<CommandResult> Dispatch<TCommand>(TCommand command)
            where TCommand : ICommand;

        //Task<IValidationResult<TCommand>> Validate<TCommand>(TCommand command)
        //    where TCommand : ICommand;
    }
}