using FinTracker.API.Models;
using FluentValidation;

namespace FinTracker.API.Validators
{
    public class CustomerModelValidator : AbstractValidator<CustomerModel>
    {
        public CustomerModelValidator()
        {

        }
    }
}