using RepForge.Application.Abstractions.Messaging;
using RepForge.Application.Abstractions.Repositories;
using RepForge.Application.Excercises;
using RepForge.Domain.Excercises;
using RepForge.Domain.Shared;
using RepForge.Domain.Users;
using RepForge.Domain.Workouts;
using RepForge.SharedKernel;

namespace RepForge.Application.Workouts.Add;
internal sealed class AddWorkoutCommandHandler
    : ICommandHandler<AddWorkoutCommand, WorkoutResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IWorkoutRepository _workoutRepository;

    public AddWorkoutCommandHandler(
        IUserRepository userRepository,
        IWorkoutRepository workoutRepository)
    {
        _userRepository = userRepository;
        _workoutRepository = workoutRepository;
    }
    public async Task<Result<WorkoutResponse>> Handle(AddWorkoutCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            return Result.Failure<WorkoutResponse>(UserErrors.NotFound);
        }

        var nameResult = Name.Create(request.Name);

        if (nameResult.IsFailure)
        {
            return Result.Failure<WorkoutResponse>(nameResult.Error);
        }

        var workout = Workout.Create(user.Id, nameResult.Value);

        await _workoutRepository.AddAsync(workout);

        return new WorkoutResponse(
            workout.Id,
            workout.UserId,
            workout.Name.Value);
    }
}
