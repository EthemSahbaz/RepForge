using RepForge.Application.Abstractions.Messaging;
using RepForge.Application.Abstractions.Repositories;
using RepForge.Domain.Excercises;
using RepForge.Domain.Excercises.Errors;
using RepForge.Domain.Shared;
using RepForge.Domain.Workouts;
using RepForge.Domain.Workouts.Errors;
using RepForge.SharedKernel;

namespace RepForge.Application.WorkoutSessions.AddExcerciseSession;
internal sealed class AddExcerciseSessionCommandHandler
    : ICommandHandler<AddExcerciseSessionCommand>
{
    private readonly IExcerciseSessionRepository _excerciseSessionRepository;
    private readonly IWorkoutSessionRepository _workoutSessionRepository;
    private readonly IExcerciseRepository _excerciseRepository;

    public AddExcerciseSessionCommandHandler(
        IExcerciseSessionRepository excerciseSessionRepository,
        IWorkoutSessionRepository workoutSessionRepository,
        IExcerciseRepository excerciseRepository
        )
    {
        _excerciseSessionRepository = excerciseSessionRepository;
        _workoutSessionRepository = workoutSessionRepository;
        _excerciseRepository = excerciseRepository;
    }
    public async Task<Result> Handle(AddExcerciseSessionCommand request, CancellationToken cancellationToken)
    {
        WorkoutSession workoutSession = await _workoutSessionRepository.GetByIdAsync(request.WorkoutSessionId);

        if(workoutSession is null)
        {
            return Result.Failure(WorkoutSessionErrors.NotFound);
        }

        var excercise = await _excerciseRepository.GetById(request.ExcerciseId);

        if (excercise is null)
        {
            return Result.Failure(ExcerciseErrors.NotFound);
        }

        var repetitionsResult = Repetitions.Create(request.Repetitions);

        if (repetitionsResult.IsFailure)
        {
            return Result.Failure(repetitionsResult.Error);
        }

        var durationResult = Duration.Create(request.StartTime, request.EndTime);

        if (durationResult.IsFailure)
        {
            return Result.Failure(durationResult.Error);
        }

        var repetitions = repetitionsResult.Value;
        var duration = durationResult.Value;

        var completeExcerciseSessionResult = workoutSession.CompleteExcercise(excercise.Id, repetitions, duration);

        if (completeExcerciseSessionResult.IsFailure)
        {
            return Result.Failure(completeExcerciseSessionResult.Error);
        }

        await _workoutSessionRepository.Update(workoutSession);

        // TODO: Send response object back.
        return Result.Success();

    }
}
