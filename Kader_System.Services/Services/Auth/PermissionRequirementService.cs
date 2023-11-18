namespace Kader_System.Services.Services.Auth;

public class PermissionRequirementService : IAuthorizationRequirement
{
    public string Permission { get; private set; }

    public PermissionRequirementService(string permission) =>
        Permission = permission;
}
