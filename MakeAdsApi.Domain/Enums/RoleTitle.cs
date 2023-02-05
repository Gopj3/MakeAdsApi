using Ardalis.SmartEnum;

namespace MakeAdsApi.Domain.Enums;

public class RoleTitle : SmartEnum<RoleTitle, string>
{
    public static readonly RoleTitle User = new(nameof(User), nameof(User));
    public static readonly RoleTitle Admin = new(nameof(Admin), nameof(Admin));
    public RoleTitle(string name, string value) : base(name, value)
    {
    }
}