using RepForge.Domain.Common;
using RepForge.Domain.Workouts;

namespace RepForge.Domain.Users.Events;
public sealed record WorkoutAddedEvent(User User, Workout Workout) : IDomainEvent;

