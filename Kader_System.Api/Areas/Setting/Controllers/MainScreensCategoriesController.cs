namespace Kader_System.Api.Areas.Setting.Controllers;

[Area(Modules.Setting)]
[ApiExplorerSettings(GroupName = Modules.Setting)]
[ApiController]
[Authorize(Permissions.Setting.View)]
[Route("api/v1/")]
public class MainScreensCategoriesController(IMainScreenCategoryService service) : ControllerBase
{
    private readonly IMainScreenCategoryService _service = service;

    [HttpGet(ApiRoutes.MainScreenCategory.ListOfMainScreensCategories)]
    public async Task<IActionResult> ListOfMainScreensCategoriesAsync() =>
        Ok(await _service.ListOfMainScreensCategoriesAsync(GetCurrentRequestLanguage()));

    [HttpGet(ApiRoutes.MainScreenCategory.GetAllMainScreenCategories)]
    public async Task<IActionResult> GetAllMainScreensCategoriesAsync(StGetAllFiltrationsForMainScreenCategoryRequest model) =>
        Ok(await _service.GetAllMainScreensCategoriesAsync(GetCurrentRequestLanguage(), model));


    [HttpPost(ApiRoutes.MainScreenCategory.CreateMainScreenCategory)]
    public async Task<IActionResult> CreateServiceAsync([FromForm] StCreateMainScreenCategoryRequest model)
    {
        var response = await _service.CreateMainScreenCategoryAsync(model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.MainScreenCategory.GetMainScreenCategoryById)]
    public async Task<IActionResult> GetMainScreenCategoryByIdAsync(int id)
    {
        var response = await _service.GetMainScreenCategoryByIdAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.MainScreenCategory.UpdateMainScreenCategory)]
    public async Task<IActionResult> UpdateServiceAsync([FromRoute] int id, [FromForm] StUpdateMainScreenCategoryRequest model)
    {
        var response = await _service.UpdateMainScreenCategoryAsync(id, model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpDelete(ApiRoutes.MainScreenCategory.DeleteMainScreenCategory)]
    public async Task<IActionResult> DeleteMainScreenCategoryAsync(int id)
    {
        var response = await _service.DeleteMainScreenCategoryAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    private string GetCurrentRequestLanguage() =>
        Request.Headers.AcceptLanguage.ToString().Split(',').First();
}
