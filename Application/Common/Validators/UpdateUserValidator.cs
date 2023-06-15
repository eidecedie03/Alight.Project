using Application.Common.Helpers;
using Application.Models.Request;
using FluentValidation;

namespace Application.Common.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        private readonly IValidationHelper _validationHelper;

        public UpdateUserValidator(IValidationHelper validationHelper)
        {
            _validationHelper = validationHelper;

            RuleFor(x => x.Id).NotNull().NotEmpty().NotEqual(0);
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.Address).SetValidator(new UpdateAddressValidator());
            RuleForEach(x => x.Employments).SetValidator(new UpdateEmploymentValidator());
        }

        private class UpdateAddressValidator : AbstractValidator<UpdateAddressRequest>
        {
            public UpdateAddressValidator()
            {
                RuleFor(x => x.Street).NotNull().NotEmpty();
                RuleFor(x => x.City).NotNull().NotEmpty();
            }
        }

        private class UpdateEmploymentValidator : AbstractValidator<UpdateEmploymentRequest>
        {
            public UpdateEmploymentValidator()
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
