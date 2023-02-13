﻿namespace Lmoe.Domain.Models.Entities.Base;

public abstract class BaseDomainEntity
{
    public Guid Id { get; }

    public DateTimeOffset CreatedAt { get; protected set; }

    public DateTimeOffset? UpdatedAt { get; protected set; }

    public DateTimeOffset? DeletedAt { get; protected set; }

    protected BaseDomainEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public void Delete()
    {
        DeletedAt = DateTimeOffset.UtcNow;
    }
}