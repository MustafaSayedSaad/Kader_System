namespace Kader_System.Api.Areas.Setting.Controllers;

[Area(Modules.Setting)]
[ApiExplorerSettings(GroupName = Modules.Setting)]
[ApiController]
[Authorize(Permissions.Setting.View)]
[Route("api/v1/")]
public class MainScreensController(IMainScreenService service) : ControllerBase
{
    private readonly IMainScreenService _service = service;

    [HttpGet(ApiRoutes.MainScreen.ListOfMainScreens)]
    public async Task<IActionResult> ListOfMainScreensAsync() =>
         Ok(await _service.ListOfMainScreensAsync(GetCurrentRequestLanguage()));


    [HttpGet(ApiRoutes.MainScreen.GetAllMainScreens)]
    public async Task<IActionResult> GetAllMainScreensAsync(StGetAllFiltrationsForMainScreenRequest model) =>
        Ok(await _service.GetAllMainScreensAsync(GetCurrentRequestLanguage(), model));


    [HttpPost(ApiRoutes.MainScreen.CreateMainScreen)]
    public async Task<IActionResult> CreateMainScreenAsync([FromForm] StCreateMainScreenRequest model)
    {
        var response = await _service.CreateMainScreenAsync(model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }


    [HttpGet(ApiRoutes.MainScreen.GetMainScreenById)]
    public async Task<IActionResult> GetMainScreenByIdAsync([FromRoute] int id)
    {
        var response = await _service.GetMainScreenByIdAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }


    [HttpPut(ApiRoutes.MainScreen.UpdateMainScreen)]
    public async Task<IActionResult> UpdateMainScreenAsync([FromRoute] int id, [FromForm] StUpdateMainScreenRequest model)
    {
        var response = await _service.UpdateMainScreenAsync(id, model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }


    [HttpDelete(ApiRoutes.MainScreen.DeleteMainScreen)]
    public async Task<IActionResult> DeleteMainScreenAsync([FromRoute] int id)
    {
        var response = await _service.DeleteMainScreenAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    private string GetCurrentRequestLanguage() =>
        Request.Headers.AcceptLanguage.ToString().Split(',').First();
}
