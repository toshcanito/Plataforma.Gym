using FluentValidation;
using FluentValidation.Validators;

namespace Plataforma.Gym.WebApi.Features.Security.Dtos.Requests
{
    public class LoginRequestValidations : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidations()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(16);
        }
    }
}