using Application.Results;

namespace Application.MenuItems;

public static class MenuItemErrors
{
	public static Error NotFound(int id) =>
		Error.NotFound("MenuItem.NotFound", $"Menu item with Id: {id} not found");
	public static Error CreateNullFailure
		=> Error.Failure("MenuItem.CreateNullFailure", "Menu item cannot be null");
	public static Error UpdateNullFailure
		=> Error.Failure("MenuItem.UpdateNullFailure", "Menu item cannot be null");

	public static Error NameTooLong(int maxLength)
		=> Error.Failure("MenuItem.NameTooLong", $"Name is too long, max length is: {maxLength}");
	public static Error NameTooShort(int minLength)
		=> Error.Failure("MenuItem.NameTooShort", $"Name is too short, min length is: {minLength}");

	public static Error DescriptionTooLong(int maxLength)
		=> Error.Failure("MenuItem.DescriptionTooLong", $"Description is too long, max length is: {maxLength}");

	public static Error PriceTooHigh(int maxPrice)
		=> Error.Failure("MenuItem.PriceTooHigh", $"Price is too high, max price is: {maxPrice}");
	public static Error NegativePrice
		=> Error.Failure("MenuItem.NegativePrice", "Price cannot be negative");
}