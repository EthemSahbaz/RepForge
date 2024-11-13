using RepForge.Domain.Workouts;

namespace RepForge.Application.Abstractions.Repositories;
internal interface IWorkoutSessionRepository
{
    Task AddAsync(WorkoutSession workoutSession);
}
