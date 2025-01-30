using Application.Abstractions.Services;
using Domain.Entities;

namespace Application.Menus.Abstractions;

public interface IMenuService : IEntityService<Menu, int>
{
}