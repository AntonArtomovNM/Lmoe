using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Base;

namespace Lmoe.Domain.Models.Entities.Contracts;

public abstract class SourceMaterialBase : DomainEntityBase
{
    public SourceType Source { get; private set; }

    public void SetSource(SourceType source)
    {
        Source = source;

        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
