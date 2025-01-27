using Application.Abstractions.Repositories;
using Domain.Abstractions;
using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Abstractions;

internal abstract class OperationsRepository<TEntity, TId>(CoreDbContext dbContext) :
	Repository<TEntity, TId>(dbContext),
	IEntityOperations<TEntity, TId>
	where TId : IComparable<TId>
	where TEntity : BaseEntity<TId>
{
	public virtual void Add(TEntity entity)
	{
		_entities.Add(entity);
	}

	public virtual void AddRange(ICollection<TEntity> entities)
	{
		_entities.AddRange(entities);
	}

	public virtual void Update(TEntity entity)
	{
		_entities.Attach(entity);
		_entities.Entry(entity).State = EntityState.Modified;
	}

	public virtual void Delete(TEntity entity)
	{
		_entities.Attach(entity);
		_entities.Remove(entity);
	}

	public virtual async Task AddAsync(TEntity entity)
	{
		await _entities.AddAsync(entity);
	}

	public virtual async Task AddRangeAsync(ICollection<TEntity> entities)
	{
		await _entities.AddRangeAsync(entities);
	}

	public virtual async Task UpdateAsync(TEntity entity)
	{
		await Task.Run(() => Update(entity));
	}

	public virtual async Task UpdateRangeAsync(ICollection<TEntity> entities)
	{
		foreach (var entity in entities)
			await UpdateAsync(entity);
	}

	public virtual async Task DeleteAsync(TEntity entity)
	{
		await Task.Run(() => Delete(entity));
	}

	public virtual async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
	{
		return await _entities.AsNoTracking().Where(x => x.Id.Equals(id)).FirstOrDefaultAsync(cancellationToken);
	}

	public virtual TEntity GetById(TId id)
	{
		return _entities.AsNoTracking().Where(x => x.Id.Equals(id)).FirstOrDefault();
	}

	public virtual async Task<ICollection<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await _entities.AsNoTracking().ToListAsync(cancellationToken);
	}

	public virtual ICollection<TEntity> GetAll()
	{
		return _entities.AsNoTracking().ToList();
	}
	public virtual async Task<bool> ExistByIdAsync(TId id, CancellationToken cancellationToken = default)
	{
		return await _entities.AnyAsync(e => e.Id.Equals(id), cancellationToken);
	}
}

internal abstract class OperationsRepository<TEntity>(CoreDbContext dbContext) :
	OperationsRepository<TEntity, int>(dbContext) where TEntity : BaseEntity<int>
{
}