using System.Net;

namespace FinTracker.Domain.Exceptions;

public class UserException : Exception
{
    public HttpStatusCode Code { get; set; }

    public UserException(HttpStatusCode code)
    {
        Code = code;
    }

    public UserException(HttpStatusCode code, string msg) : base(msg)
    {
        Code = code;
    }

    public UserException(string msg, Exception innerEx) : base(msg, innerEx)
    {

    }

    public UserException(string msg, Exception innerEx, HttpStatusCode code) : base(msg, innerEx)
    {
        Code = code;
    }
}
