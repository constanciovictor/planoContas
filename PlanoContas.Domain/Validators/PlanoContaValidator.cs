using FluentValidation;

public class PlanoContaValidator : AbstractValidator<PlanoContas.Domain.Models.PlanoContas>
{
    public PlanoContaValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .WithMessage("O nome do plano de contas é obrigatório");

        RuleFor(p => p.TipoConta)
            .NotEmpty()
            .WithMessage("O tipo de conta é obrigatório");  

        RuleFor(p => p.Codigo)
            .NotEmpty()
            .WithMessage("O código do plano de contas é obrigatório");

        RuleFor(p => p.IdPai)
            .NotEmpty() 
            .WithMessage("O plano de contas pai é obrigatório");
    }
}

