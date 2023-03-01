using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Properties;

namespace MakeAdsApi.Infrastructure.Repositories;

public class PropertyRepository: GenericRepository<Property>, IPropertyRepository
{
    public PropertyRepository(MakeAdsDbContext context) : base(context)
    {
    }
}