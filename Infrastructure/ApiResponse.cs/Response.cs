using System.Net;

namespace Infrastructure.ApiResponse.cs;

public class Response<T>
{
    public T? Data {get; set;}
    public string? Message {get; set;}
    public int StatusCode {get; set;}
    public Response(T data)
    {
        Data = data;
        Message = " ";
        StatusCode = 200;
    }
    public Response(HttpStatusCode statusCode,string message)
    {
        Data = default;
        Message = message;
        StatusCode = (int)statusCode;
    }
}