

using System.Configuration;
using System.Text.Json.Serialization;
using SharedKernel.Models.Domain.Models;

namespace SharedKernel.Response;

public class Response<TData>
{
    private readonly int _code;

    [JsonConstructor]
    public Response() 
        => _code = Configuration.DefaultStatusCode;
    public bool Success { get; set; }

    public Response(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
    {
        Data = data;
        _code = code;
        Message = message;
    }
    
    public TData? Data { get; set; }
    public string? Message { get; set; } 
    
    [JsonIgnore]
    public bool IsSuccess
        => _code is >= 200 and <= 299;

    public static Response<TData> Fail(string message)
    {
        return new Response<TData> { Success = false, Message = message };
    }
}