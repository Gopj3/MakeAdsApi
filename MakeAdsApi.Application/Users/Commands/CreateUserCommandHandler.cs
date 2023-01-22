using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Users.Models.Responses;
using MediatR;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Authentication;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Users;
using MakeAdsApi.Domain.Errors;

namespace MakeAdsApi.Application.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<UserViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;

    public CreateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IPasswordHasher<User> passwordHasher
    )
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<UserViewModel>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var existedUser = await _unitOfWork
            .UserRepository
            .GetByExpressionFirstAsync(x => x.Email == command.Email, cancellationToken);
        
        if (existedUser is not null)
        {
            return DomainErrors.User.DuplicateEmail;
        }
        
        var roles = await _unitOfWork.RoleRepository
                    .GetByExpressionAsync(x => command.RoleIds.Contains(x.Id), cancellationToken);

        var userId = Guid.NewGuid();
        var user = new User
        {
            Id = userId,
            Email = command.Email,
            Password = _passwordHasher.HashPassword(String.Empty),
            UserRoles = roles.Select(x => UserRole.Create(userId, x)).ToList()
        };

        await _unitOfWork.UserRepository.CreateAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync();

        return UserViewModel.From(user);
    }
}