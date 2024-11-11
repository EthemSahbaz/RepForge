using MediatR;
using RepForge.SharedKernel;

namespace RepForge.Application.Abstractions.Messaging;
public interface ICommand : IRequest<Result>;
public interface ICommand<TResponse> : IRequest<Result<TResponse>>;