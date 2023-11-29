namespace Kader_System.Services.IServices.Auth;

public interface IPermService
{
    // Crud of roles
    Task<Response<IEnumerable<SelectListForUserResponse>>> GetAllRolesAsync(string lang);
    Task<Response<PermCreateRoleRequest>> CreateRoleAsync(PermCreateRoleRequest model);
    Task<Response<SelectListForUserRequest>> UpdateRoleAsync(string id, SelectListForUserRequest model);
    Task<Response<string>> DeleteRoleByIdAsync(string id);

    // Spicial to roles of user
    Task<Response<PermGetAllUsersRolesResponse>> GetEachUserWithHisRolesAsync(PermGetEachUserWithRolesRequest model);
    Task<Response<PermGetManagementModelResponse>> ManageUserRolesAsync(string userId);
    Task<Response<PermGetManagementModelResponse>> UpdateUserRolesAsync(PermGetManagementModelResponse model);

    // Spicial to permissions(Claims) of role
    Task<Response<IEnumerable<GetPermissionsWithActions>>> GetAllPermissionsByCategoryNameAsync(List<string> permissionsCategoryNames);
    Task<Response<PermGetRolesPermissionsResponse>> ManageRolePermissionsAsync(string roleId);
    Task<Response<PermUpdateManagementModelRequest>> UpdateRolePermissionsAsync(PermUpdateManagementModelRequest model);

    Task<Response<PermGetPermissionsToSpecificRoleResponse>> ManageRolePermissionsAsync(string roleId, string lang);

}
