using MediatR;
using RepForge.SharedKernel;

namespace RepForge.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery,TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
