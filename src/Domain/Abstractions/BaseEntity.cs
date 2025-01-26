namespace Domain.Abstractions;

public abstract class BaseEntity<TId> : IEntity where TId : IComparable<TId>
{
	public required TId Id { get; set; }
}

public abstract class BaseEntity : BaseEntity<int>
{
}