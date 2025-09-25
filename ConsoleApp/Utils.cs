global using System;
global using System.Collections.Generic;
global using System.IO; 
global using System.Text.Json;
global using System.Text.Json.Serialization;

namespace ConsoleApp;

public enum MaiEnum
{
    Event = 1,
    Storage = 2,
    Timeline = 3,
    Exit = 4
}

public enum EventEnum
{
    TakeNode = 1,
    ShowNodeList = 2,
    DeleteNode = 3,
    Exit = 4
}

public enum StorageEnum
{
    Store = 1,
    Exit = 2
}

public enum TimelineEnum
{
    Show = 1,
    Exit = 2
}

// public class Result<T>
// {
//     public bool IsSuccess { get; }
//     public string? Error { get; }
//     public T? Value { get; }

//     private Result(string error)
//     {
//         Error = error;
//         IsSuccess = false;
//     }

//     private Result(T value)
//     {
//         Value = value;
//         IsSuccess = true;
//     }

//     public Result<T> Success(T value) => new(value);

//     public Result<T> Failure(string error) => new(error);

// }
