using RepForge.Domain.Common;

namespace RepForge.SharedKernel;
public abstract class Entity
{
    protected readonly List<IDomainEvent> _domainEvents = new();
    public Guid Id { get; init; }

    protected Entity(Guid id)
    {
        Id = id;
    }

    public List<IDomainEvent> PopDomainEvents()
    {
        var copy = _domainEvents.ToList();
        _domainEvents.Clear();

        return copy;
    }
}
