using RepForge.Domain.Excercises;
using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Workouts;
/// <summary>
/// Workout entity representing a workout that a user created with different exercises.
/// </summary>
public sealed class Workout : Entity
{
    private readonly List<ExcerciseSet> _excerciseSetIds = new();

    public Workout(
        Guid id,
        Name name) : base(id)
    {
        Name = name;
    }
    public Guid UserId { get; }
    public Name Name { get; }
    public IReadOnlyList<ExcerciseSet> ExcerciseSets => _excerciseSetIds.ToList();


    public void AddExcerciseSet(Guid excerciseId, SetCount setCount)
    {
        var excerciseSet = ExcerciseSet.Create(Id, excerciseId, setCount);

        _excerciseSetIds.Add(excerciseSet);
    }
}
