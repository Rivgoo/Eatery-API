using Domain.Abstractions;

namespace Application.Abstractions.Repositories;

public interface IAddOperations<TEntity> where TEntity : IEntity
{
	void Add(TEntity entity);
	Task AddAsync(TEntity entity);

	void AddRange(ICollection<TEntity> entities);
	Task AddRangeAsync(ICollection<TEntity> entities);
}