namespace Lmoe.Domain.Models.Entities.Base;

public abstract class DomainEntityBase
{
    public Guid Id { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; protected set; }

    public DateTimeOffset? DeletedAt { get; private set; }

    protected DomainEntityBase()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public void Delete()
    {
        DeletedAt = DateTimeOffset.UtcNow;
    }
}
