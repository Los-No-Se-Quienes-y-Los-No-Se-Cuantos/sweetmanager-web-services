namespace sweetmanager.API.Reports.Domain.Model.Commands;

public record UpdateReportCommand(int Id, string Title, string Content);