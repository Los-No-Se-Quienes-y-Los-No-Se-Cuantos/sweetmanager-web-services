using sweetmanager.API.Reports.Domain.Model.ValueObjects;

namespace sweetmanager.API.Reports.Interfaces.REST.Resources;

public record ReportResource(int Id, string Title, string Content, string Image, EReportType ReportType);