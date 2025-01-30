using Application.Abstractions.Services;
using Domain.Entities;

namespace Application.MenuItems.Abstractions;

public interface IMenuItemService : IEntityService<MenuItem, int>
{
}