using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Core;

internal sealed class CoreDbContext(DbContextOptions<CoreDbContext> options) : DbContext(options)
{
}