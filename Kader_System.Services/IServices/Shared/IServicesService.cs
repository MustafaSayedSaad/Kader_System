namespace Kader_System.Services.IServices.Shared;

public interface IServicesService
{
    Task<Response<IEnumerable<SelectListResponse>>> ListOfServicesAsync(string lang);
    Task<Response<IEnumerable<SharGetAllServicesResponse>>> GetAllServicesAsync(string lang);
    Task<Response<IEnumerable<SharGetAllServicesResponse>>> GetLastThreeServicesAsync(string lang);
    Task<Response<SharCreateServiceRequest>> CreateServiceAsync(SharCreateServiceRequest model);
    Task<Response<SharGetServiceResponse>> GetServiceByIdAsync(int id);
    Task<Response<SharEditServiceRequest>> UpdateServiceAsync(int id, SharEditServiceRequest model);
    Task<Response<string>> UpdateActiveOrNotServiceAsync(int id);
    Task<Response<string>> DeleteServiceAsync(int id);
}
