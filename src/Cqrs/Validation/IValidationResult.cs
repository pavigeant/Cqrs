namespace Cqrs.Validation
{
    /// <summary>
    /// Provides a result of the validation of a command.
    /// </summary>
    /// <typeparam name="TCommand">The type of command on which the validation occurred.</typeparam>
    public interface IValidationResult<TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Gets whether if a command has been or will be executed in its current state.
        /// </summary>
        bool Valid { get; }
    }
}