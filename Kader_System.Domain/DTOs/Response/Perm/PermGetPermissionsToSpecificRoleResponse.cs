namespace Kader_System.Domain.Dtos.Response.Perm;

public class PermGetPermissionsToSpecificRoleResponse
{
    public string RoleId { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
    public List<GetEachSubMainWithActions> EachSubMainWithActions { get; set; } = [];
}
