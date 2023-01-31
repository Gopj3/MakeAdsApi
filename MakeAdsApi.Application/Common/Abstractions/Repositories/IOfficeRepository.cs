using System;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Domain.Entities.Offices;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IOfficeRepository: IGenericRepository<Office>
{
    Task<Office?> GetWithCompanyByIdAsync(Guid id, CancellationToken cancellationToken = default);
}