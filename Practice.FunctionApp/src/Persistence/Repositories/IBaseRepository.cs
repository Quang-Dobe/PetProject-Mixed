using FunctionApp.IsolatedDemo.Api.Common;
using FunctionApp.IsolatedDemo.Api.Common.DataFiltering;
using FunctionApp.IsolatedDemo.Api.Domain.Entities;

namespace FunctionApp.IsolatedDemo.Api.Persistence.Repositories;

internal interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
{
	Task<TEntity> CreateAsync(TEntity enttiy, CancellationToken cancellationToken = default);

	Task<TEntity> UpdateAsync(TEntity enttiy, CancellationToken cancellationToken = default);

	Task DeleteAsync(TEntity enttiy, CancellationToken cancellationToken = default);

	Task<PaginationListInfo<TEntity>> SearchAsync(SearchInfo<TEntity> searchInfo, CancellationToken cancellationToken = default);

	Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);

	Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

}
