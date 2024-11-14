using RepForge.Domain.Workouts;

namespace RepForge.Application.WorkoutSessions;

public sealed record WorkoutSessionResponse(
    Guid Id,
    Guid WorkoutId,
    WorkoutState State,
    DateTime StartTime,
    DateTime EndTime);