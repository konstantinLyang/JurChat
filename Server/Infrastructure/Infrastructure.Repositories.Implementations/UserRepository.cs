using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        { }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var query = GetAll();
            return await query.ToListAsync();
        }
    }
}
