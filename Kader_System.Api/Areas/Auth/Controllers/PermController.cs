namespace Kader_System.Api.Areas.Auth.Controllers;

[Area(Modules.Auth)]
[ApiController]
[ApiExplorerSettings(GroupName = Modules.Auth)]
[Authorize(Permissions.Auth.View)]
[Route("Api/[controller]")]
public class PermController(IPermService service) : ControllerBase
{
    private readonly IPermService _service = service;

    [HttpGet(ApiRoutes.Perm.GetAllRoles)]
    public async Task<IActionResult> GetAllRolesAsync() =>
        Ok(await _service.GetAllRolesAsync());

    [HttpPost(ApiRoutes.Perm.CreateRole)]
    public async Task<IActionResult> CreateRoleAsync(PermCreateRoleRequest model)
    {
        var response = await _service.CreateRoleAsync(model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.Perm.UpdateRole)]
    public async Task<IActionResult> UpdateRoleAsync([FromRoute] string id, SelectListForUserRequest model)
    {
        var response = await _service.UpdateRoleAsync(id, model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpDelete(ApiRoutes.Perm.DeleteRoleById)]
    public async Task<IActionResult> DeleteRoleByIdAsync([FromRoute] string id)
    {
        var response = await _service.DeleteRoleByIdAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.Perm.GetEachUserWithHisRoles)]
    public async Task<IActionResult> GetEachUserWithHisRolesAsync([FromQuery] PermGetEachUserWithRolesRequest model)
    {
        var response = await _service.GetEachUserWithHisRolesAsync(model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.Perm.ManageUserRoles)]
    public async Task<IActionResult> ManageUserRolesAsync([FromRoute] string userId)
    {
        var response = await _service.ManageUserRolesAsync(userId);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPost(ApiRoutes.Perm.UpdateUserRoles)]
    public async Task<IActionResult> UpdateUserRolesAsync(PermGetManagementModelResponse model)
    {
        var response = await _service.UpdateUserRolesAsync(model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.Perm.GetAllPermissionsByCategoryName)]
    public async Task<IActionResult> GetAllPermissionsByCategoryNameAsync([FromQuery] List<string> permissionsCategoryNames) =>
        Ok(await _service.GetAllPermissionsByCategoryNameAsync(permissionsCategoryNames));

    [HttpGet(ApiRoutes.Perm.ManageRolePermissions)]
    public async Task<IActionResult> ManageRolePermissionsAsync([FromRoute] string roleId)
    {
        var response = await _service.ManageRolePermissionsAsync(roleId);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPost(ApiRoutes.Perm.UpdateRolePermissions)]
    public async Task<IActionResult> UpdateRolePermissionsAsync(PermUpdateManagementModelRequest model)
    {
        var response = await _service.UpdateRolePermissionsAsync(model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    //[AllowAnonymous]
    //[HttpPost("TestForAnything")]
    //public async Task<IActionResult> UpdateTestAsync(/*[FromForm] PermTest model*/IEnumerable<int> ids)
    //{
    //    return Ok(null);
    //}
}
