namespace Kader_System.Api.Areas.Setting.Controllers;

[Area(Modules.HR)]
[ApiExplorerSettings(GroupName = Modules.HR)]
[ApiController]
[Route("api/v1/")]
public class CompaniesController(ICompanyService service) : ControllerBase
{
    private readonly ICompanyService _service = service;

    [HttpGet(ApiRoutes.Company.ListOfCompanies)]
    public async Task<IActionResult> ListOfCompaniesAsync() =>
        Ok(await _service.ListOfCompaniesAsync(GetCurrentRequestLanguage()));

    [HttpGet(ApiRoutes.Company.GetAllCompanies)]
    public async Task<IActionResult> GetAllCompaniesAsync([FromQuery] HrGetAllFiltrationsForCompaniesRequest model) =>
        Ok(await _service.GetAllCompaniesAsync(GetCurrentRequestLanguage(), model));

    [HttpPost(ApiRoutes.Company.CreateCompany)]
    public async Task<IActionResult> CreateCompanyAsync([FromForm] HrCreateCompanyRequest model)
    {
        var response = await _service.CreateCompanyAsync(model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.Company.GetCompanyById)]
    public async Task<IActionResult> GetCompanyByIdAsync(int id)
    {
        var response = await _service.GetCompanyByIdAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.Company.UpdateCompany)]
    public async Task<IActionResult> UpdateCompanyAsync([FromRoute] int id, [FromForm] HrUpdateCompanyRequest model)
    {
        var response = await _service.UpdateCompanyAsync(id, model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpDelete(ApiRoutes.MainScreenCategory.DeleteMainScreenCategory)]
    public async Task<IActionResult> DeleteCompanyAsync(int id)
    {
        var response = await _service.DeleteCompanyAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    private string GetCurrentRequestLanguage() =>
        Request.Headers.AcceptLanguage.ToString().Split(',').First();
}
