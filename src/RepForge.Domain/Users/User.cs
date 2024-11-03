using RepForge.SharedKernel;

namespace RepForge.Domain.Users;
public sealed class User : Entity
{
    public User(Guid id) 
        : base(id)
    {
    }

    public int MyProperty { get; set; }
}
