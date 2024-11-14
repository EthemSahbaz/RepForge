using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises.Errors;
public static class ExcerciseErrors
{
    public static readonly Error NotFound = new(
    "Excercise.NotFound", "Can not find excercise with provided identifier.");
}
