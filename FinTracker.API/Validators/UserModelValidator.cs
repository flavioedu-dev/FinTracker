using FinTracker.API.Models;
using FluentValidation;

namespace FinTracker.API.Validators;

public class UserModelValidator : AbstractValidator<UserModel>
{
    public UserModelValidator()
    {

    }
}