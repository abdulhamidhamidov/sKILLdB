﻿using System.Diagnostics;
using System.Net;

namespace Infrostructure.Response;

public class Response<T>
{
    public int StatusCode { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }

    public Response(T data)
    {
        StatusCode = 200;
        Data = data;
    }

    public Response(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Message = message;
        Data = default;
    }
}