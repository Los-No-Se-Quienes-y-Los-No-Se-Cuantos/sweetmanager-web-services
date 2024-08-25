namespace sweetmanager.API.IAM.Domain.Model.Exceptions;

public class EmailAlreadyExistException(string email) : Exception($"Email {email} is already taken!");