using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Domain.Entities.Files;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Repositories;

public class UserProfileAvatarRepository: GenericRepository<UserProfileAvatar>, IUserProfileAvatarRepository
{
    public UserProfileAvatarRepository(MakeAdsDbContext context) : base(context)
    {
    }
}