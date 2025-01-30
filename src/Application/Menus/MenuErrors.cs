using Application.Results;

namespace Application.Menus;

public static class MenuErrors
{
	public static Error NotFound(int id) =>
		Error.NotFound("Menu.NotFound", $"Menu with Id: {id} not found");
	public static Error CreateNullFailure
		=> Error.Failure("Menu.CreateNullFailure", "Menu cannot be null");
	public static Error UpdateNullFailure
		=> Error.Failure("Menu.UpdateNullFailure", "Menu cannot be null");

	public static Error NameTooLong(int maxLength)
		=> Error.Failure("Menu.NameTooLong", $"Name is too long, max length is: {maxLength}");
	public static Error NameTooShort(int minLength)
		=> Error.Failure("Menu.NameTooShort", $"Name is too short, min length is: {minLength}");
}