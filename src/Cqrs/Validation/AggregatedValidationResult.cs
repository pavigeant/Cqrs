using System.Linq;

namespace Cqrs.Validation
{
    internal class AggregatedValidationResult<TCommand> : IValidationResult<TCommand>
        where TCommand : ICommand
    {
        private readonly IValidationResult<TCommand>[] _results;

        public AggregatedValidationResult(params IValidationResult<TCommand>[] results)
        {
            _results = results;
        }

        public bool Valid => _results.All(x => x.Valid);
    }
}