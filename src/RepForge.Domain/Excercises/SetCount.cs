using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises;
public sealed record SetCount
{
    private SetCount(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Result<SetCount> Create(int value)
    {
        if (value <= 0)
        {
            return Result.Failure<SetCount>(SetCountErrors.NegativeOrZeroValue);
        }

        return new SetCount(value);
    }
}
