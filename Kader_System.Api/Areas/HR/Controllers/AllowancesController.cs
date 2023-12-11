namespace Kader_System.Api.Areas.Setting.Controllers;

[Area(Modules.HR)]
[AllowAnonymous]
[ApiExplorerSettings(GroupName = Modules.HR)]
[ApiController]
[Route("api/v1/")]
public class AllowancesController(IAllowanceService service) : ControllerBase
{
    private readonly IAllowanceService _service = service;

    [HttpGet(ApiRoutes.Allowance.ListOfAllowances)]
    public async Task<IActionResult> ListOfAllowancesAsync() =>
        Ok(await _service.ListOfAllowancesAsync(GetCurrentRequestLanguage()));

    [HttpGet(ApiRoutes.Allowance.GetAllAllowances)]
    public async Task<IActionResult> GetAllAllowancesAsync([FromQuery] HrGetAllFiltrationsForAllowancesRequest model) =>
        Ok(await _service.GetAllAllowancesAsync(GetCurrentRequestLanguage(), model));

    [HttpPost(ApiRoutes.Allowance.CreateAllowance)]
    public async Task<IActionResult> CreateCompanyAsync(HrCreateAllowanceRequest model)
    {
        var response = await _service.CreateAllowanceAsync(model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.Allowance.GetAllowanceById)]
    public async Task<IActionResult> GetAllowanceByIdAsync(int id)
    {
        var response = await _service.GetAllowanceByIdAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.Allowance.UpdateAllowance)]
    public async Task<IActionResult> UpdateAllowanceAsync([FromRoute] int id, HrUpdateAllowanceRequest model)
    {
        var response = await _service.UpdateAllowanceAsync(id, model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpDelete(ApiRoutes.Allowance.DeleteAllowance)]
    public async Task<IActionResult> DeleteAllowanceAsync(int id)
    {
        var response = await _service.DeleteAllowanceAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    private string GetCurrentRequestLanguage() =>
        Request.Headers.AcceptLanguage.ToString().Split(',').First();
}
