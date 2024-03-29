using System;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Domain.Entities.Companies;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface ICompanyRepository : IGenericRepository<Company>
{
    Task<Company?> GetCompanyByIdAsync(Guid id, CancellationToken cancellationToken = default);
}