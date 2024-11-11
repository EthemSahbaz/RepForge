using MediatR;
using RepForge.SharedKernel;

namespace RepForge.Application.Abstractions.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
