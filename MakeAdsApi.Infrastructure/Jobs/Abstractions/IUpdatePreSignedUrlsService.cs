using System.Threading;
using System.Threading.Tasks;

namespace MakeAdsApi.Infrastructure.Jobs.Abstractions;

public interface IUpdatePreSignedUrlsService
{
    Task UpdatePreSignedUrlsAsync(CancellationToken cancellationToken = default);
}