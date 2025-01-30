using Application.Abstractions;
using Application.Abstractions.Services;
using Application.MenuItems.Abstractions;
using Application.Menus.Abstractions;
using Application.Results;
using Domain.Entities;

namespace Application.MenuItems;

internal class MenuItemService(
	IMenuItemRepository entityRepository,
	IUnitOfWork unitOfWork,
	IMenuService menuService) :
	BaseEntityService<MenuItem, int, IMenuItemRepository>(entityRepository, unitOfWork), IMenuItemService
{
	private readonly IMenuService _menuService = menuService;

	protected override Func<int, Error> EntityWithIdNotFound => MenuItemErrors.NotFound;
	protected override Error CreateNullFailure => MenuItemErrors.CreateNullFailure;
	protected override Error UpdateNullFailure => MenuItemErrors.UpdateNullFailure;

	public override async Task<Result<MenuItem>> CreateAsync(MenuItem newEntity)
	{
		newEntity.CreatedAt = DateTime.UtcNow;

		return await base.CreateAsync(newEntity);
	}
	public override async Task<Result<MenuItem>> UpdateAsync(MenuItem changedEntity)
	{
		changedEntity.UpdatedAt = DateTime.UtcNow;

		return await base.UpdateAsync(changedEntity);
	}

	protected override async Task<Result> ValidateEntityAsync(MenuItem entity)
	{
		if (Guard.MinLength(entity.Name, 1))
			return Result.Bad(MenuItemErrors.NameTooShort(1));

		if (Guard.MaxLength(entity.Name, 1024))
			return Result.Bad(MenuItemErrors.NameTooLong(1024));

		if (Guard.MaxLength(entity.Description, 20000))
			return Result.Bad(MenuItemErrors.DescriptionTooLong(20000));

		if(Guard.Min(entity.Price, 0))
			return Result.Bad(MenuItemErrors.NegativePrice);

		if(Guard.Max(entity.Price, 1000000))
			return Result.Bad(MenuItemErrors.PriceTooHigh(1000000));

		var menuExistsResult = await _menuService.VerifyExistsByIdAsync(entity.MenuId);

		if (menuExistsResult.IsFailure)
			return menuExistsResult;

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