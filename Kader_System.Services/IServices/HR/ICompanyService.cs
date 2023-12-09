namespace Kader_System.Services.IServices.HR;

public interface ICompanyService
{
    Task<Response<IEnumerable<StSelectListForMainScreenCategoryResponse>>> ListOfCompaniesAsync(string lang);
    Task<Response<HrGetAllCompaniesResponse>> GetAllCompaniesAsync(string lang, HrGetAllFiltrationsForCompaniesRequest model);
    Task<Response<HrCreateCompanyRequest>> CreateCompanyAsync(HrCreateCompanyRequest model);
    Task<Response<StGetMainScreenCategoryByIdResponse>> GetCompanyByIdAsync(int id);
    Task<Response<StUpdateMainScreenCategoryRequest>> UpdateCompanyAsync(int id, StUpdateMainScreenCategoryRequest model);
    Task<Response<string>> UpdateActiveOrNotCompanyAsync(int id);
    Task<Response<string>> DeleteCompanyAsync(int id);
}
