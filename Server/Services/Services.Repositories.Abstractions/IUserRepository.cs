using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<List<User>> GetAllUsersAsync();
    }
}