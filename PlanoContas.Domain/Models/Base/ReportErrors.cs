public class ReportErrors
{
    public ReportErrors()
    {
    }

    public ReportErrors(string message)
    {
        Message = message;
    }

    public string Code { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public static ReportErrors Create(string message) => new ReportErrors(message);
}


