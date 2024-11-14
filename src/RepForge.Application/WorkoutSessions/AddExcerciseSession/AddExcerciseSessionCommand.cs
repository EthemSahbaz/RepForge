using RepForge.Application.Abstractions.Messaging;

namespace RepForge.Application.WorkoutSessions.AddExcerciseSession;
public sealed record AddExcerciseSessionCommand(
    Guid WorkoutSessionId,
    Guid ExcerciseId,
    int Repetitions,
    DateTime StartTime,
    DateTime EndTime) : ICommand;
