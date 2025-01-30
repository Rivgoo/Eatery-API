using Application.Abstractions;
using Application.Abstractions.Services;
using Application.Eateries.Abstractions;
using Application.Menus.Abstractions;
using Application.Results;
using Domain.Entities;

namespace Application.Menus;

internal class MenuService(
	IMenuRepository entityRepository,
	IUnitOfWork unitOfWork,
	IEateryService eateryService) :
	BaseEntityService<Menu, int, IMenuRepository>(entityRepository, unitOfWork), IMenuService
{
	private readonly IEateryService _eateryService = eateryService;
	protected override Func<int, Error> EntityWithIdNotFound => MenuErrors.NotFound;
	protected override Error CreateNullFailure => MenuErrors.CreateNullFailure;
	protected override Error UpdateNullFailure => MenuErrors.UpdateNullFailure;

	public override async Task<Result<Menu>> CreateAsync(Menu newEntity)
	{
		newEntity.CreatedAt = DateTime.UtcNow;

		return await base.CreateAsync(newEntity);
	}
	public override async Task<Result<Menu>> UpdateAsync(Menu changedEntity)
	{
		changedEntity.UpdatedAt = DateTime.UtcNow;

		return await base.UpdateAsync(changedEntity);
	}

	protected override async Task<Result> ValidateEntityAsync(Menu entity)
	{
		if (Guard.MinLength(entity.Name, 1))
			return Result.Bad(MenuErrors.NameTooShort(1));

		if (Guard.MaxLength(entity.Name, 1024))
			return Result.Bad(MenuErrors.NameTooLong(1024));

		var eateryExistsResult = await _eateryService.VerifyExistsByIdAsync(entity.EateryId);

		if (eateryExistsResult.IsFailure)
			return eateryExistsResult;

		return Result.Ok();
	}

	public async Task<Result> SoftDeleteByIdAsync(int id)
	{
		var entityResult = await GetByIdAsync(id);

		if (entityResult.IsFailure)
			return entityResult;

		entityResult.Value!.IsDeleted = true;

		return await UpdateAsync(entityResult.Value);
	}
}