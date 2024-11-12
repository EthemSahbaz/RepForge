using RepForge.Application.Abstractions.Messaging;
using RepForge.Application.Abstractions.Repositories;
using RepForge.Domain.Users;
using RepForge.SharedKernel;

namespace RepForge.Application.Excercises.GetAll;
internal sealed class GetAllExcercisesQueryHandler
    : IQueryHandler<GetAllExcercisesQuery, IReadOnlyList<ExcerciseResponse>>
{
    private readonly IExcerciseRepository _excerciseRepository;
    private readonly IUserRepository _userRepository;

    public GetAllExcercisesQueryHandler(
        IExcerciseRepository excerciseRepository,
        IUserRepository userRepository)
    {
        _excerciseRepository = excerciseRepository;
        _userRepository = userRepository;
    }
    public async Task<Result<IReadOnlyList<ExcerciseResponse>>> Handle(GetAllExcercisesQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            return Result.Failure<IReadOnlyList<ExcerciseResponse>>(UserErrors.NotFound);
        }

        var excercises = await _excerciseRepository.GetAllAsync(request.UserId);

        return excercises
            .Select(x => new ExcerciseResponse(x.Id, x.UserId, x.Name.Value))
            .ToList();

    }
}
