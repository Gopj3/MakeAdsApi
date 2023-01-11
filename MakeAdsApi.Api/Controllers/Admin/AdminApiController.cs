using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MakeAdsApi.Api.Controllers.Admin;

[Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/admin/[controller]")]
public class AdminApiController: ApiController
{}