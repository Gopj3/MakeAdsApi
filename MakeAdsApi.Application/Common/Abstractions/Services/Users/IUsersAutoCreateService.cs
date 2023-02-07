using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.RetailProviders.Common.Models;
using MakeAdsApi.Domain.Entities.Companies;
using MakeAdsApi.Domain.Entities.Users;

namespace MakeAdsApi.Application.Common.Abstractions.Services.Users;

public interface IUsersAutoCreateService
{
    Task<User> CreateUserAndRelatedEntitiesAsync(
        RetailDataPropertyApiResponse apiResponse,
        Company company,
        CancellationToken cancellationToken);
}