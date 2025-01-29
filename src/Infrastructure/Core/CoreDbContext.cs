using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Core;

internal sealed class CoreDbContext(DbContextOptions<CoreDbContext> options) : DbContext(options)
{
	#region Tabels
	public DbSet<Eatery> Eateries { get; set; }
	public DbSet<Menu> Menus { get; set; }
	public DbSet<MenuItem> MenuItems { get; set; }
	#endregion

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<MenuItem>()
			.Property(p => p.Currency)
			.HasConversion<string>();
	}
}