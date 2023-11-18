namespace Kader_System.Services.IServices.Shared;

public interface IPoliticsService
{
    //Task<Response<IEnumerable<SelectListResponse>>> ListOfServicesCategoriesAsync(string lang);
    Task<Response<IEnumerable<SharGetAllPoliciesResponse>>> GetAllPoliciesAsync();
    //Task<Response<IEnumerable<SharGetAllClientsResponse>>> GetNumOfSpecificClientsAsync(string lang);
    Task<Response<SharCreatePolicyRequest>> CreatePolicyAsync(SharCreatePolicyRequest model);
    Task<Response<SharGetPolicyResponse>> GetPolicyByIdAsync(int id);
    Task<Response<SharEditPolicyRequest>> UpdatePolicyAsync(int id, SharEditPolicyRequest model);
    Task<Response<string>> UpdateActiveOrNotPolicyAsync(int id);
    Task<Response<string>> DeletePolicyAsync(int id);
}
