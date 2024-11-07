using RepForge.Domain.Excercises;
using RepForge.Domain.Shared;
using RepForge.Domain.Users.Events;
using RepForge.Domain.Workouts;
using RepForge.SharedKernel;

namespace RepForge.Domain.Users;
public sealed class User : Entity
{
    private readonly List<Guid> _workoutIds = new();
    private readonly List<Guid> _excericeIds = new();
    public User(Guid id, Name name)
        : base(id)
    {
        Name = name;
    }

    public Name Name { get; }

    public Result AddWorkout(Workout workout)
    {
        if (_workoutIds.Exists(id => id == workout.Id))
        {
            return Result.Failure(UserErrors.WorkoutAlreadyAdded);
        }

        _workoutIds.Add(workout.Id);

        _domainEvents.Add(new WorkoutAddedEvent(this, workout));

        return Result.Success();
    }

    public Result AddExcercise(Excercise excercise)
    {
        if (_workoutIds.Exists(id => id == excercise.Id))
        {
            return Result.Failure(UserErrors.ExcerciseAlreadyAdded);
        }

        _excericeIds.Add(excercise.Id);

        _domainEvents.Add(new ExcerciseAddedEvent(this, excercise));

        return Result.Success();
    }
}
