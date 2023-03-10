using Lmoe.Domain.Enums;
using Lmoe.Domain.Models.Entities.Base;
using Lmoe.Utils.Results;

namespace Lmoe.Domain.Models.Entities.Contracts;

public abstract class SourceMaterialBase : DomainEntityBase
{
    public SourceType Source { get; private set; }

    public Result SetSource(SourceType source)
    {
        Source = source;
        UpdatedAt = DateTimeOffset.UtcNow;

        return Result.Success();
    }
}
