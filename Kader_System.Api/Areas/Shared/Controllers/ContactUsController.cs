namespace Kader_System.Api.Areas.Auth.Controllers;

[Area(Modules.Shared)]
[ApiExplorerSettings(GroupName = Modules.Shared)]
[AllowAnonymous]
[ApiController]
[Route("Api/[controller]")]
public class ContactUsController(IContactUsService service) : ControllerBase
{
    private readonly IContactUsService _service = service;

    [HttpGet(ApiRoutes.ContactUs.GetAllContactUs)]
    public async Task<IActionResult> GetAllContactUsAsync() =>
        Ok(await _service.GetAllContactUsAsync());

    [HttpPost(ApiRoutes.ContactUs.CreateContactUs)]
    public async Task<IActionResult> CreateContactUsAsync(SharCreateContactUsRequest model)
    {
        var response = await _service.CreateContactUsAsync(model);
        if (response.IsSuccess)
            return Ok(response);
        else if (!response.IsSuccess)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }
}
