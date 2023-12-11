namespace Kader_System.Api.Areas.Setting.Controllers;

[Area(Modules.HR)]
[ApiExplorerSettings(GroupName = Modules.HR)]
[ApiController]
[Route("api/v1/")]
public class BenefitsController(IBenefitService service) : ControllerBase
{
    private readonly IBenefitService _service = service;

    [HttpGet(ApiRoutes.Benefit.ListOfBenefits)]
    public async Task<IActionResult> ListOfBenefitsAsync() =>
        Ok(await _service.ListOfBenefitsAsync(GetCurrentRequestLanguage()));

    [HttpGet(ApiRoutes.Benefit.GetAllBenefits)]
    public async Task<IActionResult> GetAllBenefitsAsync([FromQuery] HrGetAllFiltrationsForBenefitsRequest model) =>
        Ok(await _service.GetAllBenefitsAsync(GetCurrentRequestLanguage(), model));

    [HttpPost(ApiRoutes.Benefit.CreateBenefit)]
    public async Task<IActionResult> CreateBenefitAsync(HrCreateBenefitRequest model)
    {
        var response = await _service.CreateBenefitAsync(model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.Benefit.GetBenefitById)]
    public async Task<IActionResult> GetBenefitByIdAsync(int id)
    {
        var response = await _service.GetBenefitByIdAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.Benefit.UpdateBenefit)]
    public async Task<IActionResult> UpdateBenefitAsync([FromRoute] int id, HrUpdateBenefitRequest model)
    {
        var response = await _service.UpdateBenefitAsync(id, model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpDelete(ApiRoutes.Benefit.DeleteBenefit)]
    public async Task<IActionResult> DeleteAllowanceAsync(int id)
    {
        var response = await _service.DeleteBenefitAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    private string GetCurrentRequestLanguage() =>
        Request.Headers.AcceptLanguage.ToString().Split(',').First();
}
