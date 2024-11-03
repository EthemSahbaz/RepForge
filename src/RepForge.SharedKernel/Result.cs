﻿using System.Diagnostics.CodeAnalysis;

namespace RepForge.SharedKernel;
public class Result
{
    public Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !IsSuccess && error == Error.None)
        {
            throw new ArgumentException();
        }

        IsSuccess = isSuccess;
        Error = error;

    }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    public static Result Success() => new Result(true, Error.None);
    public static Result Failure(Error error) => new Result(false, error);

    public static Result<TValue> Success<TValue>(TValue value)
    => new(value, true, Error.None);

    public static Result<TValue> Failure<TValue>(Error error) =>
        new(default, false, error);
}

public sealed class Result<TValue> : Result
{
    private readonly TValue? _value;
    public Result(TValue? value, bool isSuccess, Error error) 
        : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value => IsSuccess ?
        _value! : throw new InvalidOperationException("Value of a result can not be accessed.");

    public static implicit operator Result<TValue>(TValue value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue); 

}
