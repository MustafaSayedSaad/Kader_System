namespace Kader_System.Services.IServices.Shared;

public interface IServicesCategoriesService
{
    //Task<Response<IEnumerable<SelectListResponse>>> ListOfServicesCategoriesAsync(string lang);
    Task<Response<IEnumerable<SelectListResponse>>> GetAllServicesCategoriesAsync(string lang);
    Task<Response<SharCreateServicesCategoryRequest>> CreateServicesCategoryAsync(SharCreateServicesCategoryRequest model);
    Task<Response<SharGetServicesCategoryResponse>> GetServicesCategoryByIdAsync(int id);
    Task<Response<SharGetServicesCategoryWthAllServicesResponse>> GetServicesCategoryWithAllServicesByIdAsync(int id);
    Task<Response<SharEditServicesCategoryRequest>> UpdateServicesCategoryAsync(int id, SharEditServicesCategoryRequest model);
    Task<Response<string>> UpdateActiveOrNotServicesCategoryAsync(int id);
    Task<Response<string>> DeleteServicesCategoryAsync(int id);
}
