using Application.Abstractions;
using Application.Abstractions.Services;
using Application.Eateries.Abstractions;
using Application.Results;
using Domain.Entities;

namespace Application.Eateries;

internal class EateryService(
	IEateryRepository entityRepository,
	IUnitOfWork unitOfWork) :
	BaseEntityService<Eatery, int, IEateryRepository>(entityRepository, unitOfWork), IEateryService
{
	protected override Func<int, Error> EntityWithIdNotFound => EateryErrors.NotFound;
	protected override Error CreateNullFailure => EateryErrors.CreateNullFailure;
	protected override Error UpdateNullFailure => EateryErrors.UpdateNullFailure;

	public override async Task<Result<Eatery>> CreateAsync(Eatery newEntity)
	{
		newEntity.CreatedAt = DateTime.UtcNow;

		return await base.CreateAsync(newEntity);
	}
	public override async Task<Result<Eatery>> UpdateAsync(Eatery changedEntity)
	{
		changedEntity.UpdatedAt = DateTime.UtcNow;

		return await base.UpdateAsync(changedEntity);
	}

	#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
	protected override async Task<Result> ValidateEntityAsync(Eatery entity)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
	{
		if(Guard.MinLength(entity.Name, 1))
			return Result.Bad(EateryErrors.NameTooShort(1));

		if(Guard.MaxLength(entity.Name, 1024))
			return Result.Bad(EateryErrors.NameTooLong(1024));

		return Result.Ok();
	}

	public async Task<Result> SoftDeleteByIdAsync(int id)
	{
		var entityResult = await GetByIdAsync(id);

		if(entityResult.IsFailure)
			return entityResult;

		entityResult.Value!.IsDeleted = true;

		return await UpdateAsync(entityResult.Value);
	}
}