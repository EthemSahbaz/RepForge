using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Workouts;
public sealed class Workout : Entity
{
    public Workout(
        Guid id,
        Name name) : base(id)
    {
        Name = name;
    }

    public Name Name { get; }
}
