
using RepForge.Domain.Excercises;

namespace RepForge.Application.Abstractions.Repositories;
public interface IExcerciseRepository
{
    Task AddAsync(Excercise excercise);

}
