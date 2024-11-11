using RepForge.Application.Abstractions.Messaging;
using RepForge.Application.Abstractions.Repositories;
using RepForge.Domain.Shared;
using RepForge.Domain.Users;
using RepForge.SharedKernel;

namespace RepForge.Application.Users.Add;
internal sealed class AddUserCommandHandler : ICommandHandler<AddUserCommand, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public AddUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result<UserResponse>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var nameResult = Name.Create(request.Name);

        if (nameResult.IsFailure)
        {
            return Result.Failure<UserResponse>(nameResult.Error);
        }

        Name name = nameResult.Value;

        var user = User.Create(name);

        await _userRepository.AddAsync(user);

        return new UserResponse(user.Id, user.Name.Value);

    }
}
