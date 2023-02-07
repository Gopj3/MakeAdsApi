using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Orders;

namespace MakeAdsApi.Infrastructure.Repositories;

public class OrderRepository: GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(MakeAdsDbContext context) : base(context)
    {
    }
}