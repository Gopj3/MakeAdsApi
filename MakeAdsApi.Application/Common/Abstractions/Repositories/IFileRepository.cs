using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Domain.Entities.Files;

namespace MakeAdsApi.Application.Common.Abstractions.Repositories;

public interface IFileRepository: IGenericRepository<File>
{
    Task<List<File>> GetNeedsToBeUpdatedAsync(CancellationToken cancellationToken = default);
}