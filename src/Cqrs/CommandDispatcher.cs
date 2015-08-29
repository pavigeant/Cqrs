using System.Threading.Tasks;
using Cqrs.Configuration;

namespace Cqrs
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        private readonly IContainer _container;

        public CommandDispatcher(IContainer container)
        {
            _container = container;
        }

        public async Task<CommandResult<TResult>> Dispatch<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
            where TResult : new()
        {
            var handler = _container.GetInstance<ICommandHandler<TCommand, TResult>>();
            if (handler == null)
                throw Exceptions.CommandNotHandled<TCommand>();

            return await handler.Execute(command);
        }

        public async Task<CommandResult> Dispatch<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var handler = _container.GetInstance<ICommandHandler<TCommand>>();
            if (handler == null)
                throw Exceptions.CommandNotHandled<TCommand>();

            return await handler.Execute(command);
        }

        //public async Task<IValidationResult<TCommand>> Validate<TCommand>(TCommand command) where TCommand : ICommand
        //{
        //    var validaters = _container.GetAllInstances<ICommandValidator<TCommand>>();

        //    var tasks = validaters.Select(v => v.Validate(command)).ToArray();
        //    await Task.WhenAll(tasks);

        //    var aggregated = await AggregateValidations(tasks);

        //    return aggregated;
        //}

        //private async Task<IValidationResult<TCommand>> AggregateValidations<TCommand>(Task<IValidationResult<TCommand>>[] tasks) where TCommand : ICommand
        //{
        //    if (tasks.Count() <= 1)
        //        return await tasks.FirstOrDefault();
        //    else
        //    {
        //        var aggregate = new AggregatedValidationResult<TCommand>();

        //        return aggregate;
        //    }
        //}
    }
}