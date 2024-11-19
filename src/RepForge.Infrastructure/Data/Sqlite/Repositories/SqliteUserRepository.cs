using RepForge.Application.Abstractions.Repositories;
using RepForge.Domain.Users;

namespace RepForge.Infrastructure.Data.Sqlite.Repositories;
internal class SqliteUserRepository : IUserRepository
{
    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}
