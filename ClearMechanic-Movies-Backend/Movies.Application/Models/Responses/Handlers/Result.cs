using System.Net;

namespace Movies.Application.Models.Responses.Handlers;

public class Result<T>
    where T : class
{
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public List<string> Errors { get; set; } = [];
    public T Data { get; set; } = null;

    public static Result<T> Success(T data)
    {
        return new Result<T> { StatusCode = HttpStatusCode.OK, Data = data, IsSuccess = true };
    }

    public static Result<T> Failure(List<string> errors, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
    {
        return new Result<T> { StatusCode = statusCode, Errors = errors, IsSuccess = false };
    }
}
