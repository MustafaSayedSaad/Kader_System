namespace Kader_System.Services.Services.Auth;

public class DbInitSeedsService : IDbInitSeedsService
{
    private readonly RoleManager<ApplicationRole> _roleManager;

    public DbInitSeedsService(RoleManager<ApplicationRole> roleManager) =>
        _roleManager = roleManager;

    #region Claims

    public async Task SeedClaimsForSuperAdmin()
    {
        var superAdminRole = await _roleManager.FindByNameAsync(Domain.Constants.Enums.RolesEnums.Superadmin.ToString());

        List<string> modules = new();

        foreach (var item in Enum.GetValues(typeof(PermissionsModulesEnums)))
            modules.Add(item.ToString()!);


        //string[] modules = { PermissionsModules.Companies.ToString(), PermissionsModules.Auth.ToString() };

        //string[] modules = { PermissionsModules.Companies.ToString(), PermissionsModules.Auth.ToString() };

        var allClaims = await _roleManager.GetClaimsAsync(superAdminRole!);
        List<string> allPermissions = new();
        foreach (var module in modules)
            allPermissions.AddRange(Permissions.GeneratePermissionsList(module));

        foreach (var permission in allPermissions)
            if (!allClaims.Any(c => c.Type == RolesClaims.Permission && c.Value == permission))
                await _roleManager.AddClaimAsync(superAdminRole!, new Claim(RolesClaims.Permission, permission));
    }

    #endregion
}
