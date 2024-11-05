using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises;
public sealed class ExcerciseWorkoutSet : Entity
{
    public ExcerciseWorkoutSet(
        Guid id,
        Guid workoutId,
        Guid excerciseId,
        SetCount setCount) : base(id)
    {
        WorkoutId = workoutId;
        ExcerciseId = excerciseId;
        SetCount = setCount;
    }

    public Guid WorkoutId { get; }
    public Guid ExcerciseId { get; }
    public SetCount SetCount { get; }
}
