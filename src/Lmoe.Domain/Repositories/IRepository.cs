using Lmoe.Domain.Models.Entities.Base;

namespace Lmoe.Domain.Repositories;

public interface IRepository<T> where T : BaseDomainEntity
{
    Task<T> GetById(Guid id);

    Task<ICollection<T>> GetAll();

    Task<T> Create(T entity);

    Task<T> Update(T entity);
}
