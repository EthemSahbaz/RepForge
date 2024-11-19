using RepForge.Application.Abstractions.Repositories;
using RepForge.Domain.Users;

namespace RepForge.Infrastructure.Data.InMemory.Repositories;
internal sealed class InMemoryUserRepository : IUserRepository
{
    public async Task AddAsync(User user)
    {
        
    }

    public Task<User> GetByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}
