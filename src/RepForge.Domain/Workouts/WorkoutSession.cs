using RepForge.Domain.Excercises;
using RepForge.Domain.Shared;
using RepForge.Domain.Workouts.Errors;
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
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    public Result StartSession(DateTime startTime)
    {
        if (State != WorkoutState.NotStarted)
        {
            return Result.Failure(WorkoutSessionErrors.CanNotStart);
        }

        State = WorkoutState.Started;
        StartTime = startTime;
        
        return Result.Success();
    }

    public Result FinishSession(DateTime endTime)
    {
        if (State != WorkoutState.Started)
        {
            return Result.Failure(WorkoutSessionErrors.CanNotFinish);
        }

        if (StartTime >= endTime)
        {
            return Result.Failure(WorkoutSessionErrors.StartTimeProcedesEndTime);
        }

        State = WorkoutState.Finished;
        EndTime = endTime;

        return Result.Success();
    }

    public Result CompleteExcercise(Guid excerciseId, Repetitions repetitions, Duration duration)
    {
        if (State != WorkoutState.Started)
        {
            return Result.Failure(WorkoutSessionErrors.CompletedExcerciseFailed);
        }

        var excerciseSession = ExcerciseSession.Create(Id, excerciseId, repetitions, duration);

        _completedExcercises.Add(excerciseSession);

        return Result.Success();
    }

}
