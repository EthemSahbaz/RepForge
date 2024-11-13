using RepForge.Domain.Workouts;

namespace RepForge.Application.Abstractions.Repositories;
internal interface IWorkoutRepository
{
    Task AddAsync(Workout workout);
    Task<Workout> GetById(Guid workoutId);
}
