using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises.Errors;
/// <summary>
/// Class for gathering all possible errors that can happen for setcounts. 
/// </summary>
public static class SetCountErrors
{
    public static readonly Error NegativeOrZeroValue = new(
        "SetCount.NegativeValue",
        "Setcount can not be negative or zero.");
}
