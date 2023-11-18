namespace Kader_System.Api.Areas.Auth.Controllers;

[Area(Modules.Shared)]
[ApiExplorerSettings(GroupName = Modules.Shared)]
[AllowAnonymous]
[ApiController]
[Route("Api/[controller]")]
public class ServicesCategoriesController(IServicesCategoriesService service) : ControllerBase
{
    private readonly IServicesCategoriesService _service = service;

    [AllowAnonymous]
    [HttpGet(ApiRoutes.ServicesCategory.GetAllServicesCategory)]
    public async Task<IActionResult> GetAllServicesCategoriesAsync([FromHeader] string lang = Localization.Arabic) =>
        Ok(await _service.GetAllServicesCategoriesAsync(lang));

    [HttpPost(ApiRoutes.ServicesCategory.CreateServicesCategory)]
    public async Task<IActionResult> CreateServicesCategoryAsync(SharCreateServicesCategoryRequest model)
    {
        var response = await _service.CreateServicesCategoryAsync(model);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.ServicesCategory.UpdateServicesCategory)]
    public async Task<IActionResult> UpdateServicesCategoryAsync([FromRoute] int id, SharEditServicesCategoryRequest model)
    {
        var response = await _service.UpdateServicesCategoryAsync(id, model);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.ServicesCategory.GetServicesCategoryById)]
    public async Task<IActionResult> GetServicesCategoryByIdAsync(int id)
    {
        var response = await _service.GetServicesCategoryByIdAsync(id);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.ServicesCategory.GetServicesCategoryWithAllServicesById)]
    public async Task<IActionResult> GetServicesCategoryWithAllServicesByIdAsync(int id)
    {
        var response = await _service.GetServicesCategoryWithAllServicesByIdAsync(id);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.ServicesCategory.ChangeActiveOrNot)]
    public async Task<IActionResult> UpdateActiveOrNotServicesCategoryAsync([FromRoute] int id)
    {
        var response = await _service.UpdateActiveOrNotServicesCategoryAsync(id);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpDelete(ApiRoutes.ServicesCategory.DeleteServicesCategory)]
    public async Task<IActionResult> DeleteServicesCategoryAsync(int id)
    {
        var response = await _service.DeleteServicesCategoryAsync(id);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }
}
