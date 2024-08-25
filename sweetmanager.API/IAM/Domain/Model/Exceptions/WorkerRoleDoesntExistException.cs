namespace sweetmanager.API.IAM.Domain.Model.Exceptions;

public class WorkerRoleDoesntExistException (): Exception("The specified worker role doesn't exist");