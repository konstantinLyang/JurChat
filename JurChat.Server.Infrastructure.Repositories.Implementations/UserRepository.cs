using JurChat.Domain.Entities;
using JurChat.Server.Infrastructure.EntityFramework;
using JurChat.Server.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace JurChat.Server.Infrastructure.Repositories.Implementations
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {

        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var query = GetAll();
            return await query.ToListAsync();
        }
    }
}
