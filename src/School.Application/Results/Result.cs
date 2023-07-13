namespace School.Application.Results;

public class Result : IResult
{
    public Result() { }

    public IEnumerable<string>? Messages { get; set; }

    public bool Succeeded { get; set; }

    public static IResult Fail()
        => new Result { Succeeded = false };

    public static IResult Fail(string message)
        => new Result { Succeeded = false, Messages = new [] { message } };

    public static IResult Fail(IEnumerable<string> messages)
        => new Result { Succeeded = false, Messages = messages };

    public static async Task<IResult> FailAsync(CancellationToken cancellationToken)
        => await Task.Run(Fail, cancellationToken);

    public static async Task<IResult> FailAsync(string message, CancellationToken cancellationToken)
        => await Task.Run(() => Fail(message), cancellationToken);

    public static async Task<IResult> FailAsync(IEnumerable<string> messages, CancellationToken cancellationToken)
        => await Task.Run(() => Fail(messages), cancellationToken);

    public static IResult Success()
        => new Result { Succeeded = true };

    public static IResult Success(string message)
        => new Result { Succeeded = true, Messages = new [] { message } };

    public static IResult Success(IEnumerable<string> messages)
        => new Result { Succeeded = true, Messages = messages };

    public static async Task<IResult> SuccessAsync(CancellationToken cancellationToken)
        => await Task.Run(Success, cancellationToken);

    public static async Task<IResult> SuccessAsync(string message, CancellationToken cancellationToken)
        => await Task.Run(() => Success(message), cancellationToken);

    public static async Task<IResult> SuccessAsync(IEnumerable<string> messages, CancellationToken cancellationToken)
        => await Task.Run(() => Success(messages), cancellationToken);
}

public class Result<T> : Result, IResult<T>
{
    public T? Data { get; set; }

    public Result() { }

    public new static Result<T> Fail()
        => new() { Succeeded = false };

    public new static Result<T> Fail(string message)
         => new() { Succeeded = false, Messages = new [] { message } };

    public new static Result<T> Fail(IEnumerable<string> messages)
        => new() { Succeeded = false, Messages = messages };

    public static ErrorResult<T> ReturnError(string message)
        => new() { Succeeded = false, Messages = new [] { message }, StatusCode = 500 };

    public static ErrorResult<T> ReturnError(IEnumerable<string> messages)
        => new() { Succeeded = false, Messages = messages, StatusCode = 500 };

    public new static async Task<Result<T>> FailAsync(CancellationToken cancellationToken)
        => await Task.Run(Fail, cancellationToken);

    public new static async Task<Result<T>> FailAsync(string message, CancellationToken cancellationToken)
        => await Task.Run(() => Fail(message), cancellationToken);

    public new static async Task<Result<T>> FailAsync(IEnumerable<string> messages, CancellationToken cancellationToken)
        => await Task.Run(() => Fail(messages), cancellationToken);

    public static async Task<ErrorResult<T>> ReturnErrorAsync(string message, CancellationToken cancellationToken)
        => await Task.Run(() => ReturnError(message), cancellationToken);

    public static async Task<ErrorResult<T>> ReturnErrorAsync(IEnumerable<string> messages, CancellationToken cancellationToken)
        => await Task.Run(() => ReturnError(messages), cancellationToken);

    public new static Result<T> Success()
        => new() { Succeeded = true };

    public new static Result<T> Success(string message)
        => new() { Succeeded = true, Messages = new [] { message } };

    public new static Result<T> Success(IEnumerable<string> messages)
        => new() { Succeeded = true, Messages = messages };

    public static Result<T> Success(T data)
        => new() { Succeeded = true, Data = data };

    public static Result<T> Success(T data, string message)
        => new() { Succeeded = true, Data = data, Messages = new [] { message } };

    public static Result<T> Success(T data, IEnumerable<string> messages)
        => new() { Succeeded = true, Data = data, Messages = messages };

    public new static async Task<Result<T>> SuccessAsync(CancellationToken cancellationToken)
        => await Task.Run(() => Success(), cancellationToken);

    public new static async Task<Result<T>> SuccessAsync(string message, CancellationToken cancellationToken)
        => await Task.Run(() => Success(message), cancellationToken);

    public new static async Task<Result<T>> SuccessAsync(IEnumerable<string> messages, CancellationToken cancellationToken)
        => await Task.Run(() => Success(messages), cancellationToken);

    public static async Task<Result<T>> SuccessAsync(T data, CancellationToken cancellationToken)
        => await Task.Run(() => Success(data), cancellationToken);

    public static async Task<Result<T>> SuccessAsync(T data, string message, CancellationToken cancellationToken)
        => await Task.Run(() => Success(data, message), cancellationToken);

    public static async Task<Result<T>> SuccessAsync(T data, IEnumerable<string> messages, CancellationToken cancellationToken)
        => await Task.Run(() => Success(data, messages), cancellationToken);
}

public class ErrorResult<T> : Result<T>
{
    public string Source { get; set; } = string.Empty;

    public string Exception { get; set; } = String.Empty;

    public string ErrorId { get; set; } = string.Empty;

    public string SupportMessage { get; set; } = string.Empty;

    public int StatusCode { get; set; }
}
