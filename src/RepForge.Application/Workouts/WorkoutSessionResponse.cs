using RepForge.Domain.Workouts;

namespace RepForge.Application.Workouts;

public sealed record WorkoutSessionResponse(
    Guid Id,
    Guid WorkoutId,
    WorkoutState State,
    DateTime StartTime,
    DateTime EndTime);