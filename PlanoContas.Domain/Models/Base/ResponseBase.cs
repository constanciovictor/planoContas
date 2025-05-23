namespace PlanoContas.Domain.Models.Base;

public class ResponseBase
{
    public ResponseBase()
    {
        Errors = new List<ReportErrors>();
    }

    public ResponseBase(List<ReportErrors> errors)
    {
        Errors = errors;
    }

    public ResponseBase(ReportErrors errors) : this(new List<ReportErrors> { errors })
    {
    }

    public List<ReportErrors> Errors { get; set; }

    public static ResponseBase<T> Success<T>(T data) => new ResponseBase<T>(data);
    public static ResponseBase Success() => new ResponseBase();
    public static ResponseBase Error(List<ReportErrors> errors) => new ResponseBase(errors);
    public static ResponseBase Error(ReportErrors error) => new ResponseBase(error);
    public static ResponseBase<T> Error<T>(List<ReportErrors> errors)
    {
        return new ResponseBase<T>(errors);
    }
}

public class ResponseBase<T> : ResponseBase
{
    public ResponseBase()
    {
        Errors = new List<ReportErrors>();
    }
    public ResponseBase(List<ReportErrors> errors) : base(errors)
    {
    }

    public ResponseBase(T data, List<ReportErrors>? errors = null) : base(errors!)
    {
        Data = data;
    }

    public T Data { get; set; } = default;
}




