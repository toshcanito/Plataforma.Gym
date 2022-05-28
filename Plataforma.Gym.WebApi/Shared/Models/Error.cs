namespace Plataforma.Gym.WebApi.Shared.Models
{
    public class Error
    {
        public Error(int statusCode, string? errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        public override string ToString()
        {
            return "{" + $"\"StatusCode\":{StatusCode}, \"ErrorMessage\": {ErrorMessage}" + "}";
        }
    }
}