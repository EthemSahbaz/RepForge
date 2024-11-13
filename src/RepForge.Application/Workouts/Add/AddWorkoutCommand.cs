using RepForge.Application.Abstractions.Messaging;

namespace RepForge.Application.Workouts.Add;
public sealed record AddWorkoutCommand(Guid UserId, string Name): ICommand<WorkoutResponse>;
