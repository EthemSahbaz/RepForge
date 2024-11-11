using RepForge.Application.Abstractions.Messaging;

namespace RepForge.Application.Excercises.Add;
public sealed record AddExcerciseCommand(Guid UserId, string Name) : ICommand<ExcerciseResponse>;

