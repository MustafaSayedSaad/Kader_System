namespace Kader_System.Api.Areas.Auth.Controllers;

[Area(Modules.Shared)]
[ApiExplorerSettings(GroupName = Modules.Shared)]
[AllowAnonymous]
[ApiController]
[Route("Api/[controller]")]
public class ServicesController(IServicesService service) : ControllerBase
{
    private readonly IServicesService _service = service;

    [HttpGet(ApiRoutes.Services.GetAllServices)]
    public async Task<IActionResult> GetAllServicesAsync([FromHeader] string lang = Localization.Arabic) =>
        Ok(await _service.GetAllServicesAsync(lang));

    [HttpGet(ApiRoutes.Services.GetLastThreeServices)]
    public async Task<IActionResult> GetLastThreeServicesAsync([FromHeader] string lang = Localization.Arabic)
    {
        var response = await _service.GetLastThreeServicesAsync(lang);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPost(ApiRoutes.Services.CreateService)]
    public async Task<IActionResult> CreateServiceAsync([FromForm] SharCreateServiceRequest model)
    {
        var response = await _service.CreateServiceAsync(model);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.Services.GetServicesById)]
    public async Task<IActionResult> GetServiceByIdAsync(int id)
    {
        var response = await _service.GetServiceByIdAsync(id);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.Services.UpdateServices)]
    public async Task<IActionResult> UpdateServiceAsync([FromRoute] int id, [FromForm] SharEditServiceRequest model)
    {
        var response = await _service.UpdateServiceAsync(id, model);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.Services.ChangeActiveOrNot)]
    public async Task<IActionResult> UpdateActiveOrNotServiceAsync([FromRoute] int id)
    {
        var response = await _service.UpdateActiveOrNotServiceAsync(id);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpDelete(ApiRoutes.Services.DeleteService)]
    public async Task<IActionResult> DeleteServiceAsync(int id)
    {
        var response = await _service.DeleteServiceAsync(id);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }
}
