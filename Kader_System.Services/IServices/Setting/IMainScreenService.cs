namespace Kader_System.Services.IServices.Setting;

public interface IMainScreenService
{
    Task<Response<IEnumerable<StSelectListResponse>>> ListOfMainScreensAsync(string lang);
    Task<Response<IEnumerable<StGetAllMainScreensResponse>>> GetAllMainScreensAsync(string lang);
    Task<Response<StCreateMainScreenRequest>> CreateMainScreenAsync(StCreateMainScreenRequest model);
    Task<Response<StGetMainScreenByIdResponse>> GetMainScreenByIdAsync(int id);
    Task<Response<StUpdateMainScreenRequest>> UpdateMainScreenAsync(int id, StUpdateMainScreenRequest model);
    Task<Response<string>> UpdateActiveOrNotMainScreenAsync(int id);
    Task<Response<string>> DeleteMainScreenAsync(int id);
}
