using FluentValidation;

namespace Plataforma.Gym.WebApi.Features.Security.Dtos.Requests.RegisterUser
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(25);

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(25);

            RuleFor(x => x.Email)
               .NotEmpty()
               .NotNull()
               .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,6}$")
               .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(16);

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(16)
                .Equal(x => x.Password)
                    .WithMessage("Passwords do not match."); ;
        }
    }
}