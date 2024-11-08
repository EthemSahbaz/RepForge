using RepForge.Domain.Excercises.Errors;
using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises;
public sealed record Repetitions
{
    private Repetitions(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Result<Repetitions> Create(int value)
    {
        if (value < 0)
        {
            return Result.Failure<Repetitions>(RepetitionErrors.NegativeValue);
        }

        return new Repetitions(value);
    }
}
