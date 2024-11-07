using RepForge.Domain.Excercises;
using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Workouts;
/// <summary>
/// A Workout-Session that a user completed based on a created workout.
/// </summary>
public sealed class WorkoutSession : Entity
{
    private readonly List<ExcerciseSession> _completedExcercises = new();
    public WorkoutSession(
        Guid id,
        Guid workoutId) : base(id)
    {
        WorkoutId = workoutId;
    }
    public Guid WorkoutId { get; }
    public WorkoutState State { get; private set; } = WorkoutState.NotStarted;
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    public Duration Duration { get; }

    public Result StartSession()
    {
        if (State != WorkoutState.NotStarted)
        {
            return Result.Failure(new Error("WorkoutSession", "Can not Start Session"));
        }

        State = WorkoutState.Started;
        
        // TODO: Set Starttime here with IDateTimeProvider.

        return Result.Success();
    }

}
