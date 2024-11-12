using RepForge.Application.Abstractions.Messaging;

namespace RepForge.Application.Excercises.GetAll;
public sealed record GetAllExcercisesQuery(Guid UserId) 
    : IQuery<IReadOnlyList<ExcerciseResponse>>;
