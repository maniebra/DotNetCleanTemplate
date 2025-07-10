namespace DotNetCleanTemplate.Source.Infrastructure.Commons;


/// <summary>
/// A wrapper object used to handle errors. Use as your functions' return types.
/// </summary>
public class Result<T>
{
    /// <summary>
    /// Return value on success
    /// </summary>
    public T? Value { get; private set; }

    /// <summary>
    /// Error message in case of failure
    /// </summary>
    public string? ErrorMessage { get; private set; }

    /// <summary>
    /// Determines wether the operation was successful or not.
    /// </summary>
    public bool IsSuccess { get; private set; }

    /// <summary>
    /// The exception itself in case of failure.
    /// </summary>
    public Exception? Error { get; private set; }

    private Result(bool isSuccess, T? value, string? errorMessage, Exception? error)
    {
        Value = value;
        ErrorMessage = errorMessage;
        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// Result of a successful operation.
    /// </summary>
    /// <param name="value">Return value of the successful operation.</param>
    /// <returns>An object of successful Result type.</returns>
    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value, null, null);
    }

    /// <summary>
    /// Result of a failed operation.
    /// </summary>
    /// <param name="errorMessage">Error message that describes the error</param>
    /// <returns>An Object of failure Result type.</returns>
    public static Result<T> Failure(string errorMessage)
    {
        return new Result<T>(false, default(T), errorMessage, null);
    }

    /// <summary>
    /// Result of a failed operation.
    /// </summary>
    /// <param name="error">Execption that caused the failure.</param>
    /// <param name="errorMessage">Error message that describes the error.</param>
    /// <returns>An Object of failure Result type.</returns>
    public static Result<T> Failure(Exception error, string errorMessage)
    {
        return new Result<T>(false, default(T), errorMessage, error);
    }

    /// <summary>
    /// Result of a failed operation.
    /// </summary>
    /// <param name="error">Exception that caused the error</param>
    /// <returns>An Object of failure Result type.</returns>
    public static Result<T> Failure(Exception error)
    {
        return new Result<T>(false, default(T), error.Message, error);
    }


}
