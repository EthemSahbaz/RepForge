using RepForge.Domain.Users;

namespace RepForge.Application.Abstractions.Repositories;
internal interface IUserRepository
{
    Task AddAsync(User user);
    Task<User> GetByIdAsync(Guid userId);
}
