using Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Eatery : BaseEntity
{
	[Required]
	[MaxLength(1024)]
	public string Name { get; set; } = default!;

	public bool IsDeleted { get; set; }
	[Required]
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
}