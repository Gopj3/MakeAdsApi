using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Budgets;

namespace MakeAdsApi.Infrastructure.Repositories;

public class BudgetItemRepository: GenericRepository<BudgetItem>, IBudgetItemRepository
{
    public BudgetItemRepository(MakeAdsDbContext context) : base(context)
    {
    }
}