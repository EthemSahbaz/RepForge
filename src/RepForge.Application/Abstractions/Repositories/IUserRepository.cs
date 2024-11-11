using RepForge.Domain.Users;

namespace RepForge.Application.Abstractions.Repositories;
public interface IUserRepository
{
    Task AddAsync(User user);
}
