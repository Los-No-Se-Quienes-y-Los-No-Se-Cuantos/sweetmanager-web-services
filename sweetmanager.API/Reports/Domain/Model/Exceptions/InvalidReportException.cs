namespace sweetmanager.API.Reports.Domain.Model.Exceptions;

public class InvalidReportException : Exception
{
    public InvalidReportException(string message)
        : base(message)
    {
    }
}