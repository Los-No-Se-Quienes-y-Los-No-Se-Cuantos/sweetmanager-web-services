using sweetmanager.API.Reports.Domain.Model.ValueObjects;

namespace sweetmanager.API.Reports.Interfaces.REST.Resources;

public record CreateReportResource(string Title, string Content, string Image, EReportType ReportType);