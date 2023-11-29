namespace Kader_System.Services.Services.Auth;

public class PermissionAuthorizationHandlerService(IHttpContextAccessor accessor) : AuthorizationHandler<PermissionRequirementService>
{
    private readonly IHttpContextAccessor _accessor = accessor;

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirementService requirement)
    {
        if (context.User == null)
            return;

        bool checkHubAuth =  _accessor!.HttpContext!.Request.Path == Shared.Notify; /*&& !string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Headers.Authorization);*/
        if (checkHubAuth)
        {
            context.Succeed(requirement);
            return;
        }

        bool canAccess = await Task.Run(() => context.User.Claims.Any(c => c.Type == RolesClaims.Permission && c.Value == requirement.Permission && c.Issuer == Shared.KaderSystem));
        if (canAccess)
        {
            context.Succeed(requirement);
            return;
        }
    }
}
