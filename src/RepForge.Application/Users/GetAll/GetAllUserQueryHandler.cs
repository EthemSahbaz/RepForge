using RepForge.Application.Abstractions.Messaging;
using RepForge.Application.Abstractions.Repositories;
using RepForge.SharedKernel;

namespace RepForge.Application.Users.GetAll;
internal sealed class GetAllUserQueryHandler
    : IQueryHandler<GetAllUserQuery, IReadOnlyList<UserResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result<IReadOnlyList<UserResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        
        return users
            .Select(user => new UserResponse(user.Id, user.Name.Value))
            .ToList();
    }
}
