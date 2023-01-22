using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Roles.Models;
using MediatR;

namespace MakeAdsApi.Application.Roles.Queries;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, ErrorOr<List<RoleViewModel>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRolesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<List<RoleViewModel>>> Handle(GetAllRolesQuery request,
        CancellationToken cancellationToken)
    {
        return (await _unitOfWork.RoleRepository.GetAllAsync()).Select(RoleViewModel.From).ToList();
    }
}