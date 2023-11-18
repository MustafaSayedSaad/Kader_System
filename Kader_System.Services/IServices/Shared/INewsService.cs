namespace Kader_System.Services.IServices.Shared;

public interface INewsService
{
    Task<Response<IEnumerable<SelectListForNewsResponse>>> ListOfNewsAsync(string lang);
    Task<Response<IEnumerable<SharGetAllNewsResponse>>> GetAllNewsAsync(string lang);
    Task<Response<IEnumerable<SharGetAllLastThreeNewsResponse>>> GetLastThreeNewsAsync(string lang);
    Task<Response<SharCreateNewsRequest>> CreateNewsAsync(SharCreateNewsRequest model);
    Task<Response<SharGetNewsResponse>> GetNewsByIdAsync(int id);
    Task<Response<SharEditNewsRequest>> UpdateNewsAsync(int id, SharEditNewsRequest model);
    Task<Response<string>> UpdateActiveOrNotNewsAsync(int id);
    Task<Response<string>> DeleteNewsAsync(int id);
}
