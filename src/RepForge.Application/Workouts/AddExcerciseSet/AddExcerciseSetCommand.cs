using RepForge.Application.Abstractions.Messaging;

namespace RepForge.Application.Workouts.AddExcerciseSet;
public sealed record AddExcerciseSetCommand(Guid WorkoutId, Guid ExcerciseId, int SetCount) : ICommand;
