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
    // Maybe change workout model to only accept fully ended sessions?
    private WorkoutSession(
        Guid id,
        Guid workoutId) : base(id)
    {
        WorkoutId = workoutId;
    }
    public Guid WorkoutId { get; }
    public WorkoutState State { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    public static WorkoutSession StartSession(
        Guid workoutId,
        DateTime startTime)
    {
        var workoutSession = new WorkoutSession(Guid.NewGuid(), workoutId);

        workoutSession.State = WorkoutState.Started;
        workoutSession.StartTime = startTime;
        
        return workoutSession;
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

    public Result CancelSession(DateTime endTime)
    {
        if (State != WorkoutState.Started)
        {
            return Result.Failure(WorkoutSessionErrors.CanNotFinish);
        }

        if (StartTime >= endTime)
        {
            return Result.Failure(WorkoutSessionErrors.StartTimeProcedesEndTime);
        }

        State = WorkoutState.Canceled;
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
