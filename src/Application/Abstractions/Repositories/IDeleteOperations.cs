using Domain.Abstractions;

namespace Application.Abstractions.Repositories;

public interface IDeleteOperations<TEntity> where TEntity : IEntity
{
	void Delete(TEntity entity);
	Task DeleteAsync(TEntity entity);
}