using Application.Eateries.Abstractions;
using Domain.Entities;
using Infrastructure.Abstractions;
using Infrastructure.Core;

namespace Infrastructure.Repositories;

internal class EateryRepository(CoreDbContext dbContext) :
	OperationsRepository<Eatery>(dbContext), IEateryRepository
{
}