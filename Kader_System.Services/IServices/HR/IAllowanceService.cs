﻿namespace Kader_System.Services.IServices.HR;

public interface IAllowanceService
{
    Task<Response<IEnumerable<SelectListResponse>>> ListOfAllowancesAsync(string lang);
    Task<Response<HrGetAllAllowancesResponse>> GetAllAllowancesAsync(string lang, HrGetAllFiltrationsForAllowancesRequest model);
    Task<Response<HrCreateAllowanceRequest>> CreateAllowanceAsync(HrCreateAllowanceRequest model);
    Task<Response<HrGetAllowanceByIdResponse>> GetAllowanceByIdAsync(int id);
    Task<Response<HrUpdateAllowanceRequest>> UpdateAllowanceAsync(int id, HrUpdateAllowanceRequest model);
    Task<Response<string>> UpdateActiveOrNotAllowanceAsync(int id);
    Task<Response<string>> DeleteAllowanceAsync(int id);
}
