using RepForge.Domain.Excercises;
using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Workouts;
/// <summary>
/// Workout entity representing a workout that a user created with different exercises.
/// </summary>
public sealed class Workout : Entity
{
    private readonly List<ExcerciseSet> _excerciseSets = new();

    private Workout(
        Guid id,
        Guid userId,
        Name name) : base(id)
    {
        Name = name;
        UserId = userId;
    }
    public Guid UserId { get; }
    public Name Name { get; }
    public IReadOnlyList<ExcerciseSet> ExcerciseSets => _excerciseSets.ToList();


    public static Workout Create(Guid userId, Name name)
    {
        return new Workout(Guid.NewGuid(), userId, name);
    }

    public void AddExcerciseSet(Guid excerciseId, SetCount setCount)
    {
        var excerciseSet = ExcerciseSet.Create(Id, excerciseId, setCount);

        _excerciseSets.Add(excerciseSet);
    }
}
