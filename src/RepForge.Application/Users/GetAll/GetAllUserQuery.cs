using RepForge.Application.Abstractions.Messaging;

namespace RepForge.Application.Users.GetAll;
public sealed record GetAllUserQuery() : IQuery<IReadOnlyList<UserResponse>>;
