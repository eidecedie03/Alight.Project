using Application.Common.Helpers;
using Application.Models.Request;
using FluentValidation;

namespace Application.Common.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        private readonly IValidationHelper _validationHelper;

        public CreateUserValidator(IValidationHelper validationHelper)
        {
            _validationHelper = validationHelper;

            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().MustAsync(_validationHelper.EmailNotExistsAsync).WithMessage("Email already in use"); ;
            RuleFor(x => x.Address).SetValidator(model => new CreateAddressValidator());
            RuleForEach(x => x.Employments).SetValidator(model => new CreateEmploymentValidator());
        }

        private class CreateAddressValidator : AbstractValidator<CreateAddressRequest>
        {
            public CreateAddressValidator()
            {
                RuleFor(x => x.Street).NotNull().NotEmpty();
                RuleFor(x => x.City).NotNull().NotEmpty();
            }
        }

        private class CreateEmploymentValidator : AbstractValidator<CreateEmploymentRequest>
        {
            public CreateEmploymentValidator()
            {
                RuleFor(x => x.Company).NotNull().NotEmpty();
                RuleFor(x => x.MonthsOfExperience).NotNull().NotEqual(0); ;
                RuleFor(x => x.Salary).NotNull().NotEqual(0); ;
                RuleFor(x => x.StartDate).NotNull().NotEmpty();
                RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate);
            }
        }
    }
}
