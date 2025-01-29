using Application.Abstractions.Repositories;
using Domain.Entities;

namespace Application.MenuItems.Abstractions;

public interface IMenuItemRepository : IEntityOperations<MenuItem, int>
{
}