using System.Net;

namespace FinTracker.Domain.Exceptions;

public class FinanceException : Exception
{
    public HttpStatusCode Code { get; set; }

    public FinanceException(HttpStatusCode code)
    {
        Code = code;
    }

    public FinanceException(HttpStatusCode code, string msg) : base(msg)
    {
        Code = code;
    }

    public FinanceException(HttpStatusCode code, string msg, Exception innerEx) : base(msg, innerEx)
    {
        Code = code;
    }

    public FinanceException(string msg, Exception innerEx) : base(msg, innerEx)
    {

    }

    public FinanceException(string msg, Exception innerEx, HttpStatusCode code) : base(msg, innerEx)
    {
        Code = code;
    }
}
