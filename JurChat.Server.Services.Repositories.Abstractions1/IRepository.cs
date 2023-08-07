using JurChat.Domain.Entities;

namespace JurChat.Server.Services.Repositories.Abstractions
{
    public interface IRepository
    {

    }

    public interface IRepository<T, TPrimaryKey> : IReadRepository<T, TPrimaryKey> where T : IEntity<TPrimaryKey>
    {
        bool Delete(T entity);

        bool Delete(TPrimaryKey di);

        bool Update(T entity);

        T Add(T entity);

        Task<T> AddAsync(T entity);

        void SaveChanges();

        Task<T> SaveChangesAsync(CancellationTokenSource cancellationToken = default);
    }
}
