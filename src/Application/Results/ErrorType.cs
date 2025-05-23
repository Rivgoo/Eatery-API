﻿namespace Application.Results;

/// <summary>
/// Represents the types of errors that can occur in the application.
/// </summary>
public enum ErrorType
{
	Failure = 0,
	NotFound = 1,
	Validation = 2,
	Conflict = 3,
	AccessUnAuthorized = 4,
	AccessForbidden = 5,
	InternalServerError = 6
}