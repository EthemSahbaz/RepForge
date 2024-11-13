namespace RepForge.Application.Workouts;

public sealed record WorkoutResponse(Guid Id, Guid UserId, string Name);