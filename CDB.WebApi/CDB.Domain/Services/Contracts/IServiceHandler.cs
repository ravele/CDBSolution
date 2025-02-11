using CDB.Domain.Services.Dtos;

namespace CDB.Domain.Services.Contracts;

public interface IServiceHandler<in TRequest> : IServiceHandler<TRequest, ServiceResult> where TRequest : class { }

public interface IServiceHandler<in TRequest, TResult> where TRequest : class where TResult : ServiceResult
{
    Task<TResult> HandleAsync(TRequest request, CancellationToken cancellationToken);
}