using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Users;
public sealed class User : Entity
{
    private User(Guid id, Name name)
        : base(id)
    {
        Name = name;
    }

    public Name Name { get; }

    public static User Create(Name name)
    {
        return new User(Guid.NewGuid(), name);
    }
}
