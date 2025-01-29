using Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Menu : BaseEntity
{
	[Required]
	[MaxLength(1024)]
	public string Name { get; set; } = default!;

	[Required]
	public int EateryId { get; set; }
	public Eatery Eatery { get; set; } = default!;

	public bool IsDeleted { get; set; }
	[Required]
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
}