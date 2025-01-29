using Application.Abstractions.Repositories;
using Domain.Entities;

namespace Application.Menus.Abstractions;

public interface IMenuRepository : IEntityOperations<Menu, int>
{
}