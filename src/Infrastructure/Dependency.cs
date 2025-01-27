﻿using Application.Abstractions;
using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Dependency
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDatabasePovider(configuration);

		services.AddScoped<IUnitOfWork, UnitOfWork>();

		return services;
	}

	private static IServiceCollection AddDatabasePovider(this IServiceCollection services, IConfiguration configuration)
	{
		var databaseProviders = new Dictionary<string, Action<IServiceCollection>>()
		{
			{ "InMemory", services => services.AddDbContext<CoreDbContext>(options => options.UseInMemoryDatabase("restaurant")) },
		};

		var databaseProviderName = configuration["DatabaseProvider"];

		if(string.IsNullOrEmpty(databaseProviderName))
			throw new ArgumentNullException(nameof(configuration), "Database provider is not specified");

		if (databaseProviders.TryGetValue(databaseProviderName, out var databaseProvider))
			databaseProvider(services);
		else
			throw new NotSupportedException($"Database provider {databaseProviderName} is not supported.");

		return services;
	}
}