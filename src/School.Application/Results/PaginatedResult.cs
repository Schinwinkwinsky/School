namespace School.Application.Results;

public class PaginatedResult<T> : IResult
{
    public IEnumerable<T>? Data { get; set; }

    public long? Count { get; set; }

    public int? Skip { get; set; }

    public int? Top { get; set; }

    public IEnumerable<string>? Messages { get; set; }

    public bool Succeeded { get; set; }

    public PaginatedResult(IEnumerable<T>? data)
    {
        Data = data;
    }

    internal PaginatedResult(bool succeeded, IEnumerable<T>? data, IEnumerable<string>? messages = null, long? count = 0, int? skip = 0, int? top = 100)
    {
        Count = count;
        Data = data;
        Messages = messages;
        Skip = skip;
        Succeeded = succeeded;
        Top = top;
    }

    public static PaginatedResult<T> Failure(IEnumerable<string> messages)
    {
        return new(false, default, messages);
    }

    public static PaginatedResult<T> Success(IEnumerable<T> data, long? count, int? skip, int? top)
    {
        return new(true, data, null, count, skip, top);
    }
}
