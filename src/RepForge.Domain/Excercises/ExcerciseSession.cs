using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises;
/// <summary>
/// Exercise-Session that represents an completed a exercise once.
/// </summary>
public sealed class ExcerciseSession : Entity
{
    private ExcerciseSession(
        Guid id,
        Guid workoutSessionId,
        Guid excerciseId,
        Repetitions repetitions,
        Duration duration) : base(id)
    {
        WorkoutSessionId = workoutSessionId;
        ExcerciseId = excerciseId;
        Repetitions = repetitions;
        Duration = duration;
    }
    /// <summary>
    /// Id of the belonging Workout-Session.
    /// </summary>
    public Guid WorkoutSessionId { get; }

    /// <summary>
    /// Id of the belonging Exercise.
    /// </summary>
    public Guid ExcerciseId { get; }

    /// <summary>
    /// Count of repetitions.
    /// </summary>
    public Repetitions Repetitions { get; }

    /// <summary>
    /// Duration of the Exercise-Session.
    /// </summary>
    public Duration Duration { get; }

    internal static ExcerciseSession Create(
        Guid workoutSessionId,
        Guid excerciseId,
        Repetitions repetitions,
        Duration duration)
    {
        return new ExcerciseSession(Guid.NewGuid(), workoutSessionId, excerciseId, repetitions, duration);
    }
}
