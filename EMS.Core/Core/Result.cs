using System.Net;

namespace EMS.Application.Core
{
    public sealed class Result<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public T? Value { get; set; }

        public string? Error { get; set; }



        public static Result<T> Success(HttpStatusCode statusCode , T? value = default)
        {
            return new Result<T> { StatusCode = statusCode, Value = value };
        }

        public static Result<T> Failure(HttpStatusCode statusCode, string error)
        {
            return new Result<T> { StatusCode = statusCode, Error = error };
        }

    }
}
