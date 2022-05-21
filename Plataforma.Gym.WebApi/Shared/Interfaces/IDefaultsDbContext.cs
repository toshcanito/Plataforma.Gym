namespace Plataforma.Gym.WebApi.Shared.Interfaces
{
    public interface IDefaultsDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        int SaveChanges();
    }
}