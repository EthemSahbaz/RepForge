using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises;
public static class SetCountErrors
{
    public static readonly Error NegativeOrZeroValue = new(
        "SetCount.NegativeValue",
        "Setcount can not be negative.");
}
