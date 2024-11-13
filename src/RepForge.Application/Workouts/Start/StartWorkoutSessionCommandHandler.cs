using RepForge.Application.Abstractions.Messaging;
using RepForge.Application.Abstractions.Repositories;
using RepForge.Domain.Workouts;
using RepForge.Domain.Workouts.Errors;
using RepForge.SharedKernel;

namespace RepForge.Application.Workouts.Start;
internal class StartWorkoutSessionCommandHandler
    : ICommandHandler<StartWorkoutSessionCommand, WorkoutSessionResponse>
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IWorkoutSessionRepository _workoutSessionRepository;

    public StartWorkoutSessionCommandHandler(
        IWorkoutRepository workoutRepository,
        IWorkoutSessionRepository workoutSessionRepository)
    {
        _workoutRepository = workoutRepository;
        _workoutSessionRepository = workoutSessionRepository;
    }
    public async Task<Result<WorkoutSessionResponse>> Handle(StartWorkoutSessionCommand request, CancellationToken cancellationToken)
    {
        Workout workout = await _workoutRepository.GetById(request.WorkoutId);

        if (workout == null)
        {
            return Result.Failure<WorkoutSessionResponse>(WorkoutErrors.NotFound);
        }

        WorkoutSession workoutSession = WorkoutSession.StartSession(workout.Id, request.StartTime);

        await _workoutSessionRepository.AddAsync(workoutSession);

        return new WorkoutSessionResponse(
            workoutSession.Id,
            workoutSession.WorkoutId,
            workoutSession.State,
            workoutSession.StartTime,
            workoutSession.EndTime);

    }
}
