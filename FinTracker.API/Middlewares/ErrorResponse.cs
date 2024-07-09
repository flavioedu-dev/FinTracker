using System.Net;
using System.Text.Json.Serialization;

namespace FinTracker.API.Middlewares;

public class ErrorResponse
{
    [JsonPropertyName("sucess")]
    public bool Sucess { get; set; }

    [JsonPropertyName ("message")]
    public string Message { get; set; }
}