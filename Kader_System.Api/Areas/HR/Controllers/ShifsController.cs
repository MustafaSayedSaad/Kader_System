﻿namespace Kader_System.Api.Areas.Setting.Controllers;

[Area(Modules.HR)]
[AllowAnonymous]
[ApiExplorerSettings(GroupName = Modules.HR)]
[ApiController]
[Route("api/v1/")]
public class ShifsController(IShiftService service) : ControllerBase
{
    private readonly IShiftService _service = service;

    [HttpGet(ApiRoutes.Shift.ListOfShifts)]
    public async Task<IActionResult> ListOfShiftsAsync() =>
        Ok(await _service.ListOfShiftsAsync(GetCurrentRequestLanguage()));

    [HttpGet(ApiRoutes.Shift.GetAllShifts)]
    public async Task<IActionResult> GetAllShiftsAsync([FromQuery] HrGetAllFiltrationsForShiftsRequest model) =>
        Ok(await _service.GetAllShiftsAsync(GetCurrentRequestLanguage(), model));

    [HttpPost(ApiRoutes.Shift.CreateShift)]
    public async Task<IActionResult> CreateShiftAsync(HrCreateShiftRequest model)
    {
        var response = await _service.CreateShiftAsync(model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpGet(ApiRoutes.Shift.GetShiftById)]
    public async Task<IActionResult> GetShiftByIdAsync(int id)
    {
        var response = await _service.GetShiftByIdAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpPut(ApiRoutes.Shift.UpdateShift)]
    public async Task<IActionResult> UpdateShiftAsync([FromRoute] int id, HrUpdateShiftRequest model)
    {
        var response = await _service.UpdateShiftAsync(id, model);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    [HttpDelete(ApiRoutes.Shift.DeleteShift)]
    public async Task<IActionResult> DeleteShiftAsync(int id)
    {
        var response = await _service.DeleteShiftAsync(id);
        if (response.Check)
            return Ok(response);
        else if (!response.Check)
            return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
        return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
    }

    private string GetCurrentRequestLanguage() =>
        Request.Headers.AcceptLanguage.ToString().Split(',').First();
}
