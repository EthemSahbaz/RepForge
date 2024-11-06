using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises;
/// <summary>
/// Value for how often an exercise needs to be completed within a workout.
/// </summary>
public sealed record SetCount
{
    private SetCount(int value)
    {
        Value = value;
    }
    /// <summary>
    /// Value of the setcount.
    /// </summary>
    public int Value { get; }
    /// <summary>
    /// Creates an setcount value object.
    /// </summary>
    /// <param name="value">Value of the setcount.</param>
    /// <returns>Returns an result of a setcount.</returns>
    public static Result<SetCount> Create(int value)
    {
        if (value <= 0)
        {
            return Result.Failure<SetCount>(SetCountErrors.NegativeOrZeroValue);
        }

        return new SetCount(value);
    }
}
