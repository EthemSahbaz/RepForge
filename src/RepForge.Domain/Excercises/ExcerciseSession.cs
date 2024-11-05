using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises;
public sealed class ExcerciseSession : Entity
{
    public ExcerciseSession(
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

    public Guid WorkoutSessionId { get; }
    public Guid ExcerciseId { get; }
    public Repetitions Repetitions { get; }
    public Duration Duration { get; }

}
