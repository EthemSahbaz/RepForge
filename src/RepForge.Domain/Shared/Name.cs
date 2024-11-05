using RepForge.SharedKernel;

namespace RepForge.Domain.Shared;
public sealed record Name
{
    private Name(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Name> Create(string value)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<Name>(Error.NullValue);
        }

        return new Name(value);
    }

}
