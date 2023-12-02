namespace Kader_System.Api.Areas.Setting.Controllers;

[Area(Modules.Setting)]
[ApiExplorerSettings(GroupName = Modules.Setting)]
[ApiController]
[Authorize(Permissions.Setting.View)]
[Route("api/v1/")]
public class SubSubMainScreensController(ISubMainScreenService service) : ControllerBase
{
    private readonly ISubMainScreenService _service = service;

    [HttpGet(ApiRoutes.SubMainScreen.ListOfSubMainScreens)]
    public async Task<IActionResult> ListOfSubMainScreensAsync() =>
         Ok(await _service.ListOfSubMainScreensAsync(GetCurrentRequestLanguage()));


    [HttpGet(ApiRoutes.SubMainScreen.GetAllSubMainScreens)]
    public async Task<IActionResult> GetAllSubMainScreensAsync([FromQuery] StGetAllFiltrationsForSubMainScreenRequest model) =>
        Ok(await _service.GetAllSubMainScreensAsync(GetCurrentRequestLanguage(), model));


    [HttpPost(ApiRoutes.SubMainScreen.CreateSubMainScreen)]
    public async Task<IActionResult> CreateSubMainScreenAsync([FromForm] StCreateSubMainScreenRequest model)
    {
        var response = await _service.CreateSubMainScreenAsync(model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }


    [HttpGet(ApiRoutes.SubMainScreen.GetSubMainScreenById)]
    public async Task<IActionResult> GetSubMainScreenByIdAsync([FromRoute] int id)
    {
        var response = await _service.GetSubMainScreenByIdAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }


    [HttpPut(ApiRoutes.SubMainScreen.UpdateSubMainScreen)]
    public async Task<IActionResult> UpdateSubMainScreenAsync([FromRoute] int id, [FromForm] StUpdateSubMainScreenRequest model)
    {
        var response = await _service.UpdateSubMainScreenAsync(id, model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }


    [HttpDelete(ApiRoutes.SubMainScreen.DeleteSubMainScreen)]
    public async Task<IActionResult> DeleteSubMainScreenAsync([FromRoute] int id)
    {
        var response = await _service.DeleteSubMainScreenAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    private string GetCurrentRequestLanguage() =>
        Request.Headers.AcceptLanguage.ToString().Split(',').First();
}
