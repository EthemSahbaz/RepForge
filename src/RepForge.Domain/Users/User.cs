using RepForge.Domain.Shared;
using RepForge.SharedKernel;

namespace RepForge.Domain.Users;
public sealed class User : Entity
{
    public User(Guid id, Name name)
        : base(id)
    {
        Name = name;
    }

    public Name Name { get; }
}
