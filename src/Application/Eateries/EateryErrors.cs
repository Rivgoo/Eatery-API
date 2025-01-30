using Application.Results;

namespace Application.Eateries;

public static class EateryErrors
{
	public static Error NotFound(int id) =>
		Error.NotFound("Eatery.NotFound", $"Eatery with Id: {id} not found");
	public static Error CreateNullFailure
		=> Error.Failure("Eatery.CreateNullFailure", "Eatery cannot be null");
	public static Error UpdateNullFailure
		=> Error.Failure("Eatery.UpdateNullFailure", "Eatery cannot be null");

	public static Error NameTooLong(int maxLength)
		=> Error.Failure("Eatery.NameTooLong", $"Name is too long, max length is: {maxLength}");
	public static Error NameTooShort(int minLength)
		=> Error.Failure("Eatery.NameTooShort", $"Name is too short, min length is: {minLength}");
}