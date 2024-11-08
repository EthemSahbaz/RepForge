using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises;
/// <summary>
/// Exercise that a user can create and add to a workout.
/// </summary>
public sealed class Excercise : Entity
{
    private Excercise(Guid id, Guid userId, Name name) : base(id)
    {
        UserId = userId;
        Name = name;
    }

    /// <summary>
    /// Id of the user.
    /// </summary>
    public Guid UserId { get; }

    /// <summary>
    /// Name of the Exercise.
    /// </summary>
    public Name Name { get; }

    /// <summary>
    /// Creates an exercise.
    /// </summary>
    /// <param name="id">Id of the exercise.</param>
    /// <param name="userId">Id of the user.</param>
    /// <param name="name">Name of the exercise.</param>
    /// <returns>Returns an valid exercise.</returns>
    public static Excercise Create(Guid userId, Name name)
    {
        return new Excercise(Guid.NewGuid(), userId ,name);
    }
}
