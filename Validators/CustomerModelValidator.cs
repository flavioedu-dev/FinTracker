using FinTracker.API.Models;
using FluentValidation;

namespace FinTracker.API.Validators
{
    public class CustomerModelValidator : AbstractValidator<CustomerModel>
    {
        public CustomerModelValidator()
        {
            RuleFor(x => x.Participant)
                .NotEmpty()
                .WithMessage("Obrigatório");

            RuleFor(x => x.Reason)
                .NotEmpty()
                .WithMessage("Obrigatório"); ;
        }
    }
}