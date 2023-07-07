namespace EfSample.Domain.SeedOfWork;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));

}
