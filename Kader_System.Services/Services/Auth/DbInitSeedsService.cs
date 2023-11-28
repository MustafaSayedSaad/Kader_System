﻿namespace Kader_System.Services.Services.Auth;

public class DbInitSeedsService(RoleManager<ApplicationRole> roleManager, IUnitOfWork unitOfWork) : IDbInitSeedsService
{
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    #region Claims

    public async Task SeedClaimsForSuperAdmin()
    {
        var superAdminRole = await _roleManager.FindByNameAsync(RolesEnums.Superadmin.ToString());

        List<string> modules = [];

        foreach (var item in Enum.GetValues(typeof(PermissionsModulesEnums)))
            modules.Add(item.ToString()!);

        var allClaims = await _roleManager.GetClaimsAsync(superAdminRole!);
        List<string> allPermissions = [];
        foreach (string module in modules)
            allPermissions.AddRange(Permissions.GeneratePermissionsList(module));

        foreach (string permission in allPermissions)
            if (!allClaims.Any(c => c.Type == RolesClaims.Permission && c.Value == permission))
            {
                await _roleManager.AddClaimAsync(superAdminRole!, new Claim(RolesClaims.Permission, permission));

                await _unitOfWork.RoleClaims.AddAsync(new ApplicationRoleClaim
                {
                    RoleId = superAdminRole!.Id,
                    ClaimType = RolesClaims.Permission,
                    ClaimValue = permission,
                    Sub_title = "s",
                    Screen_code = "1_s",
                    Url = "ss",

                });

            }
    }

    #endregion
}
