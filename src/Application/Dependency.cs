using Application.Eateries;
using Application.Eateries.Abstractions;
using Application.MenuItems;
using Application.MenuItems.Abstractions;
using Application.Menus;
using Application.Menus.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Dependency
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddScoped<IEateryService, EateryService>();
		services.AddScoped<IMenuService, MenuService>();
		services.AddScoped<IMenuItemService, MenuItemService>();

		return services;
	}
}