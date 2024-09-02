namespace sweetmanager.API.Inspection.Domain.Model.Commands;

public record CreateTaskCommand(
    string Name,
    string Description,
    int WorkerId
    );