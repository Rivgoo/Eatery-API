using Domain.Abstractions;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class MenuItem : BaseEntity
{
	[Required]
	[MaxLength(1024)]
	public string Name { get; set; } = default!;

	[MaxLength(20000)]
	public string Description { get; set; } = default!;

	[Required]
	public decimal Price { get; set; }
	[Required]
	public Currency Currency { get; set; }

	[Required]
	public int MenuId { get; set; }
	public Menu Menu { get; set; } = default!;

	public bool IsDeleted { get; set; }
	[Required]
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
}