using System.Net;
using System.Text.Json.Serialization;

namespace LearningApp.DataSource;

#pragma warning disable CS1591

public class DataState<T>
{
    [JsonPropertyName("isSuccess")] public bool IsSuccess { get; private set; }
    [JsonPropertyName("value")] public T? Value { get; private set; }
    [JsonPropertyName("errorMessage")] public string? ErrorMessage { get; private set; }
    [JsonPropertyName("statusCode")] public int StatusCode { get; private set; }

    public static DataState<T> Success(T value, int statusCode)
    {
        return new DataState<T> { IsSuccess = true, Value = value, StatusCode = statusCode };
    }

    public static DataState<T> Failure(string errorMessage, int statusCode)
    {
        return new DataState<T> { IsSuccess = false, ErrorMessage = errorMessage, StatusCode = statusCode };
    }
}