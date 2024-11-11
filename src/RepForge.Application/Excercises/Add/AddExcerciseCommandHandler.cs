using RepForge.Application.Abstractions.Messaging;
using RepForge.Application.Abstractions.Repositories;
using RepForge.Application.Users;
using RepForge.Domain.Excercises;
using RepForge.Domain.Shared;
using RepForge.Domain.Users;
using RepForge.SharedKernel;

namespace RepForge.Application.Excercises.Add;
internal sealed class AddExcerciseCommandHandler
    : ICommandHandler<AddExcerciseCommand, ExcerciseResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IExcerciseRepository _excerciseRepository;

    public AddExcerciseCommandHandler(
        IUserRepository userRepository,
        IExcerciseRepository excerciseRepository)
    {
        _userRepository = userRepository;
        _excerciseRepository = excerciseRepository;
    }
    public async Task<Result<ExcerciseResponse>> Handle(AddExcerciseCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            return Result.Failure<ExcerciseResponse>(UserErrors.NotFound);
        }

        var nameResult = Name.Create(request.Name);

        if (nameResult.IsFailure)
        {
            return Result.Failure<ExcerciseResponse>(nameResult.Error);
        }

        var excercise = Excercise.Create(user.Id, nameResult.Value);

        await _excerciseRepository.AddAsync(excercise);

        return new ExcerciseResponse(
            excercise.Id,
            excercise.UserId,
            excercise.Name.Value);
    }
}
