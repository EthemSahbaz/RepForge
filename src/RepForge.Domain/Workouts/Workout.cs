using RepForge.Domain.Excercises;
using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Workouts;
/// <summary>
/// Workout entity representing a workout that a user created with different exercises.
/// </summary>
public sealed class Workout : Entity
{
    private readonly List<ExcerciseWorkoutSet> _workoutSets = new();
    private readonly List<WorkoutSession> _workoutSessions = new();

    public Workout(
        Guid id,
        Name name) : base(id)
    {
        Name = name;
    }
    public Guid UserId { get; }
    /// <summary>
    /// Name of the workout.
    /// </summary>
    public Name Name { get; }
}
