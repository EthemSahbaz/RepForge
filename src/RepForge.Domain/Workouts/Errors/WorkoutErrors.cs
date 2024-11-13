using RepForge.SharedKernel;

namespace RepForge.Domain.Workouts.Errors;
public static class WorkoutErrors
{
    public static readonly Error NotFound = new(
        "Workout.NotFound", "Can not find workout with provided identifier.");
}
