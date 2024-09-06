using sweetmanager.API.Reports.Domain.Model.Commands;
using sweetmanager.API.Reports.Domain.Model.ValueObjects;

namespace sweetmanager.API.Reports.Domain.Model.Aggregates;

public  partial class Report
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public string Image { get; set; } //https://www.youtube.com/watch?v=eIpAdzFP5-I&t=100
    
    public EReportType ReportType { get; set; }

    public Report()
    {
        this.Content = string.Empty;
        this.Title = string.Empty; 
        this.Image = string.Empty;
        this.ReportType = EReportType.EscasosRecursos;
    }
    
    public Report(CreateReportCommand command)
    {
        this.Title = command.Title;
        this.Content = command.Content;
        this.Image = command.Image;
        this.ReportType = command.ReportType;
    }
    
    public void Update(UpdateReportCommand command)
    {
        this.Title = command.Title;
        this.Content = command.Content;
        this.Image = command.Image;
        this.ReportType = command.ReportType;
    }
    
    public void Delete()
    {
        this.Title = string.Empty;
        this.Content = string.Empty;
        this.Image = string.Empty;
        this.ReportType = EReportType.EscasosRecursos;
    }
}