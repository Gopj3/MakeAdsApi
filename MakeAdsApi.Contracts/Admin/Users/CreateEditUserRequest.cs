using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MakeAdsApi.Contracts.Admin.Users;

public record CreateEditUserRequest(
    string Email, List<Guid> RoleIds
);