using Domain.Abstractions;

namespace Application.Abstractions.Repositories;

public interface IUpdateOperations<TEntity> where TEntity : IEntity
{
	void Update(TEntity entity);
	Task UpdateAsync(TEntity entity);
	Task UpdateRangeAsync(ICollection<TEntity> entities);
}