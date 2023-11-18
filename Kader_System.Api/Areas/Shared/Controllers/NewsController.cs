namespace Kader_System.Api.Areas.Auth.Controllers;

[Area(Modules.Shared)]
[ApiExplorerSettings(GroupName = Modules.Shared)]
[AllowAnonymous]
[ApiController]
[Route("Api/[controller]")]
public class NewsController(INewsService service) : ControllerBase
{
    private readonly INewsService _service = service;

    [HttpGet(ApiRoutes.News.GetAllNews)]
    public async Task<IActionResult> GetAllNewsAsync([FromHeader] string lang = Localization.Arabic) =>
        Ok(await _service.GetAllNewsAsync(lang));

    [HttpGet(ApiRoutes.News.GetLastThreeNews)]
    public async Task<IActionResult> GetLastThreeNewsAsync([FromHeader] string lang = Localization.Arabic) =>
        Ok(await _service.GetLastThreeNewsAsync(lang));

    [HttpPost(ApiRoutes.News.CreateNews)]
    public async Task<IActionResult> CreateNewsAsync([FromForm] SharCreateNewsRequest model)
    {
        var response = await _service.CreateNewsAsync(model);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.News.GetNewsById)]
    public async Task<IActionResult> GetNewsByIdAsync(int id)
    {
        var response = await _service.GetNewsByIdAsync(id);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.News.UpdateNews)]
    public async Task<IActionResult> UpdateNewsAsync([FromRoute] int id, [FromForm] SharEditNewsRequest model)
    {
        var response = await _service.UpdateNewsAsync(id, model);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.News.ChangeActiveOrNot)]
    public async Task<IActionResult> UpdateActiveOrNotNewsAsync([FromRoute] int id)
    {
        var response = await _service.UpdateActiveOrNotNewsAsync(id);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpDelete(ApiRoutes.News.DeleteNews)]
    public async Task<IActionResult> DeleteNewsAsync(int id)
    {
        var response = await _service.DeleteNewsAsync(id);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }
}
