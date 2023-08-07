using JurChat.Domain.Entities;

namespace JurChat.Server.Services.Repositories.Abstractions
{
    public interface IReadRepository<T, TPrimaryKey> : IRepository where T : IEntity<TPrimaryKey>
    {
        IQueryable<T> GetAll(bool noTracking = false);

        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default, bool asNoTracking = false);

        T Get(TPrimaryKey id);

        Task<T> GetAsync(TPrimaryKey id);
    }
}