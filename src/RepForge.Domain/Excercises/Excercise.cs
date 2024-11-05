using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Excercises;
public sealed class Excercise : Entity
{
    private Excercise(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public Name Name { get; }

    public static Excercise Create(Guid id, Name name)
    {
        return new Excercise(id, name);
    }
}
