using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Base;

namespace Lmoe.Domain.Models.Entities.Contracts;

public abstract class BaseSourceMaterial : BaseDomainEntity
{
    public SourceType Source { get; protected set; }

    public string Name { get; protected set; }

    public void SetSource(SourceType source)
    {
        Source = source;
    }
}
