using Application.Abstractions.Services;
using Application.Results;
using Domain.Entities;

namespace Application.Eateries.Abstractions;

public interface IEateryService : IEntityService<Eatery, int>
{
	Task<Result> SoftDeleteByIdAsync(int id);
}