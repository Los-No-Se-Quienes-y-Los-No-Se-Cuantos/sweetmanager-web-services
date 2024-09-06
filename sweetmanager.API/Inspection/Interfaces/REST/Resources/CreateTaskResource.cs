namespace sweetmanager.API.Inspection.Interfaces.REST.Resources;

public record CreateTaskResource(string Title, string Description, int WorkerId);