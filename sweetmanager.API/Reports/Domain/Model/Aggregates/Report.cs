using sweetmanager.API.Reports.Domain.Model.Commands;

namespace sweetmanager.API.Reports.Domain.Model.Aggregates;

public  partial class Report
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Content { get; set; }

    public Report()
    {
        this.Content = string.Empty;
        this.Title = string.Empty; 
    }
    
    public Report(CreateReportCommand command)
    {
        this.Title = command.Title;
        this.Content = command.Content;
    }
    
    public void Update(UpdateReportCommand command)
    {
        this.Title = command.Title;
        this.Content = command.Content;
    }
    
    public void Delete()
    {
        this.Title = string.Empty;
        this.Content = string.Empty;
    }
}