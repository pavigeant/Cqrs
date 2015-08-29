using System.Threading.Tasks;

namespace Cqrs.Validation
{
    /// <summary>
    /// Provides a validation process for a command.
    /// Multiple validation may exists for a single command.
    /// A command will not be executed if one or more validations fail.
    /// </summary>
    /// <typeparam name="TCommand">The type of command that is validated by this validater.</typeparam>
    public interface ICommandValidator<TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Executes the validation of the command and returns the result.
        /// </summary>
        /// <param name="command">The type of command to validate.</param>
        Task<IValidationResult<TCommand>> Validate(TCommand command);
    }
}