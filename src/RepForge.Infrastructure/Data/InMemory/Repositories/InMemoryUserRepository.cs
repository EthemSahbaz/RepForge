using RepForge.Application.Abstractions.Repositories;
using RepForge.Domain.Shared;
using RepForge.Domain.Users;

namespace RepForge.Infrastructure.Data.InMemory.Repositories;
internal sealed class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public InMemoryUserRepository()
    {
        _users.Add(CreateDummy());
    }
    public Task AddAsync(User user)
    {
        _users.Add(user);

        return Task.CompletedTask;
    }

    public async Task<IReadOnlyList<User>> GetAllAsync()
    {
        return _users;

    }

    public Task<User?> GetByIdAsync(Guid userId)
    {
        return Task.FromResult(_users.FirstOrDefault(user => user.Id == userId));
    }

    private User CreateDummy()
    {
        var name = Name.Create("Dummy");

        var dummyUser = User.Create(name.Value);

        return dummyUser;
    }
}
