using RepForge.Domain.Common;
using RepForge.Domain.Excercises;
using RepForge.Domain.Workouts;

namespace RepForge.Domain.Users.Events;
public sealed record ExcerciseAddedEvent(User User, Excercise Excercise) : IDomainEvent;

