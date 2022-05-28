using FluentValidation;

namespace Plataforma.Gym.WebApi.Features.Security.Dtos.Requests
{
    public class LoginRequestValidations : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidations()
        {
            RuleFor(x => x.Username).EmailAddress();
            RuleFor(x => x.Password).MinimumLength(6).MaximumLength(16);
        }
    }
}