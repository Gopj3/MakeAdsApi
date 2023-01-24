using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Users;
using MakeAdsApi.Domain.Errors;
using MediatR;

namespace MakeAdsApi.Application.Users.Commands.Admin;

public class EditUserCommandHandler: IRequestHandler<EditUserCommand, ErrorOr<object>>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ErrorOr<object>> Handle(EditUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(command.Id, cancellationToken);

        if (user is null)
        {
            return DomainErrors.User.NotFound;
        }
        
        var existedUsers = await _unitOfWork
            .UserRepository
            .GetByExpressionAsync(x => x.Email == command.Email, cancellationToken);
        
        if (existedUsers.Any())
        {
            return DomainErrors.User.DuplicateEmail;
        }
        
        user.Email = command.Email;
        user.UserRoles = command.RoleIds.Select(x => new UserRole {RoleId = x, UserId = user.Id}).ToList();
        
        _unitOfWork.UserRepository.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return default;
    }
}