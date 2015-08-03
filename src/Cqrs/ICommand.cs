namespace Cqrs
{
    public interface ICommand
    {
    }

    /// <summary>
    /// Marker interface to mark a command
    /// </summary>
    public interface ICommand<TResult> : ICommand
        where TResult : new()
    {
    }
}