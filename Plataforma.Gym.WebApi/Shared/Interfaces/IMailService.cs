using Plataforma.Gym.WebApi.Shared.Models;

namespace Plataforma.Gym.WebApi.Shared.Interfaces
{
    public interface IMailService
    {
        void SendEmail(MailRequest request);
    }
}