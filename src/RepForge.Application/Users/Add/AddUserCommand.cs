using RepForge.Application.Abstractions.Messaging;

namespace RepForge.Application.Users.Add;
public sealed record AddUserCommand(string Name) : ICommand<UserResponse>;
