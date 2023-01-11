using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_PersonalFinance.Core.Dto;
using Task6_PersonalFinance.DataAccess.Context;

namespace Task6_PersonalFinance.Core.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(FinancesDbContext dbContext) 
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required")
                .Length(3, 10).WithMessage("Username must contain between 2-10 characters")
                .Custom((value, context) =>
                {
                    var nameInUse = dbContext.Users.Any(u => u.UserName == value);
                    if (nameInUse)
                    {
                        context.AddFailure("Email", "Username is already in use");
                    }
                });

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email has incorrect format")
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "Email is already in use");
                    }
                });

            RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage("Password must contain at least 6 characters");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Password and Confirm Pasword does not match");
        }
    }
}
