using System.Threading;
using System.Threading.Tasks;

namespace MakeAdsApi.Application.Common.Abstractions.Jobs;

public interface IUpdatePreSignedUrlsService
{
    Task UpdatePreSignedUrlsAsync(CancellationToken cancellationToken = default);
}