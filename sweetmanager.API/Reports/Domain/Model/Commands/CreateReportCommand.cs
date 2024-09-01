using sweetmanager.API.Reports.Domain.Model.ValueObjects;

namespace sweetmanager.API.Reports.Domain.Model.Commands;

public record CreateReportCommand(string Title, string Content, string Image, EReportType ReportType);