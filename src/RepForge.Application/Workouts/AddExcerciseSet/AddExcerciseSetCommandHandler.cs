using RepForge.Application.Abstractions.Messaging;
using RepForge.Application.Abstractions.Repositories;
using RepForge.Domain.Excercises;
using RepForge.Domain.Excercises.Errors;
using RepForge.Domain.Workouts.Errors;
using RepForge.SharedKernel;

namespace RepForge.Application.Workouts.AddExcerciseSet;
internal sealed class AddExcerciseSetCommandHandler
    : ICommandHandler<AddExcerciseSetCommand>
{
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IExcerciseRepository _excerciseRepository;
    private readonly IWorkoutSessionRepository _workoutSessionRepository;

    public AddExcerciseSetCommandHandler(
        IWorkoutRepository workoutRepository,
        IExcerciseRepository excerciseRepository,
        IWorkoutSessionRepository workoutSessionRepository)
    {
        _workoutRepository = workoutRepository;
        _excerciseRepository = excerciseRepository;
        _workoutSessionRepository = workoutSessionRepository;
    }
    public async Task<Result> Handle(AddExcerciseSetCommand request, CancellationToken cancellationToken)
    {
        var setCount = SetCount.Create(request.SetCount);

        if (setCount.IsFailure)
        {
            return Result.Failure(setCount.Error);
        }

        var workout = await _workoutRepository.GetById(request.WorkoutId);

        if (workout is null)
        {
            return Result.Failure(WorkoutErrors.NotFound);
        }

        // Check for ongoing workout session?
        
        var excercise = await _excerciseRepository.GetById(request.ExcerciseId);

        if (excercise is null)
        {
            return Result.Failure(ExcerciseErrors.NotFound);
        }


        workout.AddExcerciseSet(excercise.Id, setCount.Value);

        await _workoutRepository.UpdateAsync(workout);

        return Result.Success();
    }
}
