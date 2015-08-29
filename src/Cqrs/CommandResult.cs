namespace Cqrs
{
    public class CommandResult
    {
        public bool Succeed { get; set; }

        public static CommandResult Success() => new CommandResult { Succeed = true };

        public static CommandResult Fail() => new CommandResult { Succeed = false };
    }


    public class CommandResult<TResult> : CommandResult where TResult : new()
    {
        public TResult Result { get; set; }

        public static CommandResult<TResult> Success(TResult result) => new CommandResult<TResult> { Succeed = true, Result = result };

        public static CommandResult<TResult> Fail(TResult result) => new CommandResult<TResult> { Succeed = false, Result = default(TResult) };
    }
}