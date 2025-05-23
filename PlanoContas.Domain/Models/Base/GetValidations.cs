using FluentValidation.Results;
using PlanoContas.Domain.Models.Base;

public static class GetValidations
{
    public static ResponseBase GetErrors(this ValidationResult result)
    {
        var response = new ResponseBase();

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                response.Errors.Add(new ReportErrors()
                {
                    Code = error.PropertyName,
                    Message = error.ErrorMessage
                });
            }
        }

        return response;
    }
}
