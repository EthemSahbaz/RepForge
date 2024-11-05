using RepForge.Domain.Excercises;
using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Workouts;
public sealed class WorkoutSession : Entity
{
    public WorkoutSession(
        Guid id,
        Guid workoutId,
        List<ExcerciseSession> excerciseSessions,
        Duration duration) : base(id)
    {
        WorkoutId = workoutId;
        ExcerciseSessions = excerciseSessions;
        Duration = duration;
    }
    public Guid WorkoutId { get; }
    public List<ExcerciseSession> ExcerciseSessions { get; }
    public Duration Duration { get; }
}
