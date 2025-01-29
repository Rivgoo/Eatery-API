using Application.MenuItems.Abstractions;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Core;

namespace Infrastructure.Repositories;

internal class MenuItemRepository(CoreDbContext dbContext) :
	OperationsRepository<MenuItem>(dbContext), IMenuItemRepository
{
}