
using RepForge.Domain.Excercises;

namespace RepForge.Application.Abstractions.Repositories;
internal interface IExcerciseRepository
{
    Task AddAsync(Excercise excercise);
    Task<IReadOnlyList<Excercise>> GetAllAsync(Guid userId);
    Task<Excercise> GetById(Guid excerciseId);
}
