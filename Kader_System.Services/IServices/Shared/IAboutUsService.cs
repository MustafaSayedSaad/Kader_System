namespace Kader_System.Services.IServices.Shared;

public interface IAboutUsService
{
    Task<Response<IEnumerable<SelectListResponse>>> ListOfAboutUsAsync(string lang);
    Task<Response<SharGetAllAboutUsResponse>> GetAboutUsAsync(string lang);
    Task<Response<SharCreateAboutUsRequest>> CreateAboutUsAsync(SharCreateAboutUsRequest model);
    Task<Response<SharGetAboutUsResponse>> GetAboutUsForEditAsync();
    Task<Response<SharEditAboutUsRequest>> UpdateAboutUsAsync(SharEditAboutUsRequest model);
    //Task<Response<string>> UpdateActiveOrNotNewsAsync(int id);
    Task<Response<string>> DeleteAboutUsAsync(int id);
}
