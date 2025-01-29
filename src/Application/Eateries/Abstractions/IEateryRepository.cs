using Application.Abstractions.Repositories;
using Domain.Entities;

namespace Application.Eateries.Abstractions;

public interface IEateryRepository : IEntityOperations<Eatery, int>
{
}