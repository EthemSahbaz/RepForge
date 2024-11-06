using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Workouts;
/// <summary>
/// Workout entity representing a workout that a user created with different exercises.
/// </summary>
public sealed class Workout : Entity
{
    public Workout(
        Guid id,
        Name name) : base(id)
    {
        Name = name;
    }
    /// <summary>
    /// Name of the workout.
    /// </summary>
    public Name Name { get; }
}
