namespace Kader_System.Services.Services.Auth;

public class PermissionAuthorizationHandlerService : AuthorizationHandler<PermissionRequirementService>
{
    private readonly IHttpContextAccessor _accessor;

    public PermissionAuthorizationHandlerService(IHttpContextAccessor accessor) =>
        _accessor = accessor;

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirementService requirement)
    {
        if (context.User == null)
            return;

        bool checkHubAuth =  _accessor!.HttpContext!.Request.Path == SD.Shared.Notify; /*&& !string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Headers.Authorization);*/
        if (checkHubAuth)
        {
            context.Succeed(requirement);
            return;
        }

        bool canAccess = await Task.Run(() => context.User.Claims.Any(c => c.Type == RolesClaims.Permission && c.Value == requirement.Permission && c.Issuer == SD.Shared.Kader));
        if (canAccess)
        {
            context.Succeed(requirement);
            return;
        }
    }
}
