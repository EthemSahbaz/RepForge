using RepForge.SharedKernel;

namespace RepForge.Domain.Workouts.Errors;
public static class WorkoutSessionErrors
{
    public static readonly Error NotFound = new(
        "WorkoutSession.NotFound", "Can not find WorkoutSession with provided identifier.");

    public static readonly Error CanNotStart = new(
        "WorkoutSession.CanNotStart", "Can not start an ongoing, finished or canceled workout session.");

    public static readonly Error CanNotFinish = new(
        "WorkoutSession.CanNotFinish", "Can not finish not started, already finished or canceled workout session.");

    public static readonly Error CompletedExcerciseFailed = new(
        "WorkoutSession.CompletedExcerciseFailed", "Completed excercises can only be added on an ongoing workout session.");

    public static readonly Error StartTimeProcedesEndTime = new(
        "WorkoutSession.StartTimeProcedesEndTime", "Can not finish a workout, where start time procedes end time.");

}
