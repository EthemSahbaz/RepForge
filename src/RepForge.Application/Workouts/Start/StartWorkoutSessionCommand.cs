using RepForge.Application.Abstractions.Messaging;

namespace RepForge.Application.Workouts.Start;
public sealed record StartWorkoutSessionCommand(Guid WorkoutId, DateTime StartTime) 
    : ICommand<WorkoutSessionResponse>;
