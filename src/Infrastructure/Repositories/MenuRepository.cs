using Application.Menus.Abstractions;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Core;

namespace Infrastructure.Repositories;

internal class MenuRepository(CoreDbContext dbContext) :
	OperationsRepository<Menu, int>(dbContext), IMenuRepository
{
}