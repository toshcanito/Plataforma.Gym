namespace Plataforma.Gym.WebApi.Features.Security.Dtos.Requests.RegisterUser
{
    public record RegisterUserRequest(
        string FirstName, 
        string LastName,
        string Email,
        string Password,
        string ConfirmPassword
    );

}