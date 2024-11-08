using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises.Errors;
public static class RepetitionErrors
{
    public static readonly Error NegativeValue = new(
    "Repetition.NegativeValue",
    "Repetitions can not be negative.");
}
