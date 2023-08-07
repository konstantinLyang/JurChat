using JurChat.Domain.Entities;

namespace JurChat.Server.Services.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<List<User>> GetAllUsersAsync();
    }
}