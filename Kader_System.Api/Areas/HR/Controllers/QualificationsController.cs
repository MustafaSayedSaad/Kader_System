namespace Kader_System.Api.Areas.Setting.Controllers;

[Area(Modules.HR)]
[ApiExplorerSettings(GroupName = Modules.HR)]
[ApiController]
[Route("api/v1/")]
public class QualificationsController(IQualificationService service) : ControllerBase
{
    private readonly IQualificationService _service = service;

    [HttpGet(ApiRoutes.Qualification.ListOfQualifications)]
    public async Task<IActionResult> ListOfQualificationsAsync() =>
        Ok(await _service.ListOfQualificationsAsync(GetCurrentRequestLanguage()));

    [HttpGet(ApiRoutes.Qualification.GetAllQualifications)]
    public async Task<IActionResult> GetAllDeductionsAsync([FromQuery] HrGetAllFiltrationsForQualificationsRequest model) =>
        Ok(await _service.GetAllQualificationsAsync(GetCurrentRequestLanguage(), model));

    [HttpPost(ApiRoutes.Qualification.CreateQualification)]
    public async Task<IActionResult> CreateDeductionAsync(HrCreateQualificationRequest model)
    {
        var response = await _service.CreateQualificationAsync(model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.Qualification.GetQualificationById)]
    public async Task<IActionResult> GetDeductionByIdAsync(int id)
    {
        var response = await _service.GetQualificationByIdAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.Qualification.UpdateQualification)]
    public async Task<IActionResult> UpdateDeductionAsync([FromRoute] int id, HrUpdateQualificationRequest model)
    {
        var response = await _service.UpdateQualificationAsync(id, model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpDelete(ApiRoutes.Qualification.DeleteQualification)]
    public async Task<IActionResult> DeleteDeductionAsync(int id)
    {
        var response = await _service.DeleteQualificationAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    private string GetCurrentRequestLanguage() =>
        Request.Headers.AcceptLanguage.ToString().Split(',').First();
}
