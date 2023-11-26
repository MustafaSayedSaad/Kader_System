﻿namespace Kader_System.Services.Services.Auth;

public class PermissionPolicyProviderService(IOptions<AuthorizationOptions> options) : IAuthorizationPolicyProvider
{
    public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; } = new DefaultAuthorizationPolicyProvider(options);

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() =>
         FallbackPolicyProvider.GetDefaultPolicyAsync();

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() =>
         FallbackPolicyProvider.GetDefaultPolicyAsync()!;

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith(RolesClaims.Permission, StringComparison.OrdinalIgnoreCase))
        {
            var policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new PermissionRequirementService(policyName));
            return Task.FromResult(policy.Build())!;
        }
        else if (policyName.Equals(RolesClaims.DomainRestricted))
        {
            var policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new PermissionRequirementService(policyName));
            return Task.FromResult(policy.Build())!;
        }
        return FallbackPolicyProvider.GetPolicyAsync(policyName)!;
    }
}
