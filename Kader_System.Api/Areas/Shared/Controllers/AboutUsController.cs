namespace Kader_System.Api.Areas.Auth.Controllers;

[Area(Modules.Shared)]
[ApiExplorerSettings(GroupName = Modules.Shared)]
[AllowAnonymous]
[ApiController]
[Route("Api/[controller]")]
public class AboutUsController(IAboutUsService service) : ControllerBase
{
    private readonly IAboutUsService _service = service;

    [HttpGet(ApiRoutes.AboutUs.GetAboutUs)]
    public async Task<IActionResult> GetAboutUsAsync([FromHeader] string lang = Localization.Arabic) =>
        Ok(await _service.GetAboutUsAsync(lang));

    [HttpPost(ApiRoutes.AboutUs.CreateAboutUs)]
    public async Task<IActionResult> CreateAboutUsAsync([FromForm] SharCreateAboutUsRequest model)
    {
        var response = await _service.CreateAboutUsAsync(model);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.AboutUs.GetAboutUsForEdit)]
    public async Task<IActionResult> GetAboutUsForEditAsync()
    {
        var response = await _service.GetAboutUsForEditAsync();
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.AboutUs.UpdateAboutUs)]
    public async Task<IActionResult> UpdateAboutUsAsync([FromForm] SharEditAboutUsRequest model)
    {
        var response = await _service.UpdateAboutUsAsync(model);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpDelete(ApiRoutes.AboutUs.DeleteAboutUs)]
    public async Task<IActionResult> DeleteAboutUsAsync(int id)
    {
        var response = await _service.DeleteAboutUsAsync(id);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }
}
